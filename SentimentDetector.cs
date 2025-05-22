using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBotPart2
{
    public delegate string SentimentHandler(string message);

    public class SentimentDetector
    {
        private Dictionary<string, string> sentimentResponses = new Dictionary<string, string>()
        {
            {"worried", "It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe."},
            {"curious", "That's a great question! Let's explore that topic further."},
            {"frustrated", "I understand this can be frustrating. Let's take a step back and see if we can clarify things for you."},
            {"unsure", "No worries at all! Cybersecurity can be a lot to take in. Feel free to ask any questions you have."}
        };

        public string DetectSentiment(string message)
        {
            string lowerMessage = message.ToLower();
            foreach (var sentiment in sentimentResponses.Keys)
            {
                if (lowerMessage.Contains(sentiment))
                {
                    return sentimentResponses[sentiment];
                }
            }
            return null; // No specific sentiment detected
        }
    }
}
