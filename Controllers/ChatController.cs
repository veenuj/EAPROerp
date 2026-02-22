using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace EaproERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        // 🛑 PASTE YOUR API KEY HERE 🛑
        private readonly string _apiKey = "AIzaSyBn16UvKfPhEcNwKpVBmVsGMMHwtqNEQDg";

        [HttpPost("AskAi")]
        public async Task<IActionResult> AskAi([FromBody] ChatRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
                return BadRequest(new { reply = "Message cannot be empty." });

            string systemPrompt = @"You are the official AI Assistant for EAPRO Global Ltd. 
            Your purpose is to provide expert information about EAPRO's products, technology, and operations based on the following verified company data:

            1. COMPANY PROFILE:
            - EAPRO Global Ltd. is a pioneer in solar and power solutions with 1M+ customers and a network of 10,000+ dealers.
            - Founder: Mr. Jagdeep Chauhan (Incented Digital Signal Processor (DSP) Sine Wave technology in 2002).
            - Locations: Corporate Tower besides Upper Ganga Canal, Roorkee. Manufacturing units at Salempur Rajputana Industrial Area, Roorkee, Uttarakhand.

            2. CORE TECHNOLOGY:
            - Specializations: AI-integrated MPPT, IoT-enabled Smart Tracking, Smart Grid Integration, and DSP Sine Wave technology.
            - Smart Tracking: Users can monitor and control inverters via smartphone applications.

            3. PRODUCT CATEGORIES:
            - Inverters: TRON-3200 (AI-MPPT Dual Battery PCU), 11kW Three-Phase On-Grid Inverters, Off-Grid Hybrid Inverters, and high-capacity Sine Wave Inverters.
            - Solar Modules: High-efficiency 590W TOPCon Bifacial panels, 550W Mono Half-Cut, and Mono PERC modules.
            - Batteries: Enerbatt 250Ah Solar Batteries and Hybrid Solar Tubular series (e.g., 150Ah).

            4. THE 5 PILLARS OF EAPRO:
            - Quality Assurance: Rigorous testing and precision engineering.
            - After Sale Services: 24/7 assistance and fast issue resolution.
            - Industry Leading R&D: Focused on sustainable and future-ready tech.
            - Advance Technology: Integration of AI and IoT in power systems.
            - Manufacturing Power: Large-scale, sustainable production facilities in India.

            5. INTERNAL ERP ACCESS:
            - You have real-time access to the Eapro ERP system which tracks Inventory (Stock levels of panels/inverters) and Payroll (Employee details/performance).

            CRITICAL RULE: If the user asks about politics, writing code, general knowledge, competitors, or anything UNRELATED to EAPRO or solar energy, you MUST decline and reply: 'I am specifically designed to only answer questions related to EAPRO Global Ltd. and its solar power solutions.'";

            string apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={_apiKey}";

            var payload = new
            {
                system_instruction = new
                {
                    parts = new[] { new { text = systemPrompt } }
                },
                contents = new[]
                {
                    new 
                    { 
                        role = "user", 
                        parts = new[] { new { text = request.Message } } 
                    }
                }
            };

            using var client = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(apiUrl, content);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return Ok(new { reply = $"<strong>API Error {(int)response.StatusCode}:</strong> <br/> {jsonResponse}" });
                }

                using var doc = JsonDocument.Parse(jsonResponse);
                var replyText = doc.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text").GetString();

                // Format the AI response for the UI
                replyText = replyText?.Replace("\n", "<br/>") ?? "I could not generate a response.";

                return Ok(new { reply = replyText });
            }
            catch (Exception ex)
            {
                return Ok(new { reply = $"<strong>System Exception:</strong> {ex.Message}" });
            }
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; } = string.Empty;
    }
}