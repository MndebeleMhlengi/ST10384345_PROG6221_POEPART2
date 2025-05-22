using System;
using System.Collections.Generic;
using System.Linq;


namespace CyberSecurityBotPart2
{
 public class Chatbot
    {
        private User user;
        private Dictionary<string, string> memory = new Dictionary<string, string>();
        private ResponseGenerator responseGenerator = new ResponseGenerator();
        private SentimentDetector sentimentDetector = new SentimentDetector();
        private List<string> conversationHistory = new List<string>();
        private string currentTopic = null;

        public void GreetUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nHi there! What’s your name? ");
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Name can’t be empty. Try again: ");
                name = Console.ReadLine();
            }

            user = new User { Name = name.Trim() };
            memory["name"] = user.Name;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nWelcome, {user.Name}! 👋");
            Console.ResetColor();
        }

        public void StartChat()
        {
            Console.WriteLine("\nAsk me anything about cybersecurity (type 'exit' to quit):");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                string input = Console.ReadLine();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("🤖: I didn’t quite catch that. Could you rephrase?");
                    continue;
                }

                conversationHistory.Add($"You: {input}");

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("🤖: Stay safe online! Thank you for your time! 👋");
                    break;
                }

                string response = GetChatbotResponse(input);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"🤖: {response}");
                Console.ResetColor();

                conversationHistory.Add($"🤖: {response}");
            }
        }

        private string GetChatbotResponse(string query)
        {
            string lowerQuery = query.ToLower().Trim();

            // Sentiment Detection
            string sentimentResponse = sentimentDetector.DetectSentiment(lowerQuery);
            if (sentimentResponse != null)
            {
                return sentimentResponse;
            }

            // Keyword Recognition
            if (lowerQuery.Contains("password"))
            {
                currentTopic = "password safety";
                return responseGenerator.GetResponse("password");
            }
            else if (lowerQuery.Contains("scam"))
            {
                currentTopic = "scams";
                return responseGenerator.GetResponse("scam");
            }
            else if (lowerQuery.Contains("privacy"))
            {
                currentTopic = "privacy";
                // Store user's interest in privacy
                if (!memory.ContainsKey("favorite_topic"))
                {
                    memory["favorite_topic"] = "privacy";
                    return $"Great! I'll remember that you're interested in privacy. It's a crucial part of staying safe online. {responseGenerator.GetResponse("privacy")}";
                }
                return responseGenerator.GetResponse("privacy");
            }
            else if (lowerQuery.Contains("phishing tip"))
            {
                currentTopic = "phishing";
                return responseGenerator.GetResponse("phishing tip");
            }
            else if (lowerQuery.Contains("phishing"))
            {
                currentTopic = "phishing";
                return "Phishing is a type of online fraud where attackers try to trick you into revealing personal information... Be cautious!";
            }
            else if (lowerQuery.Contains("safe browsing") || lowerQuery.Contains("browse safely"))
            {
                currentTopic = "safe browsing";
                return "To browse safely, keep your web browser and antivirus software up to date... Avoid public Wi-Fi for sensitive tasks.";
            }
            else if (lowerQuery.Contains("malware"))
            {
                currentTopic = "malware";
                return "Malware is malicious software designed to damage or disrupt systems... Regularly update your software to patch vulnerabilities.";
            }
            else if (lowerQuery.Contains("social engineering"))
            {
                currentTopic = "social engineering";
                return "Social engineering is the manipulation of people to gain access to sensitive information... Never share passwords or sensitive data with unknown parties.";
            }
            else if (lowerQuery.Contains("data privacy"))
            {
                currentTopic = "data privacy";
                return "Data privacy is crucial. Be mindful of the information you share online... Keep your software updated.";
            }
            else if (lowerQuery.Contains("mobile security"))
            {
                currentTopic = "mobile security";
                return "For mobile security, use a strong passcode or biometric authentication... Review app permissions regularly.";
            }
            else if (lowerQuery.Contains("ransomware"))
            {
                currentTopic = "ransomware";
                return "Ransomware is a type of malware that encrypts your files and demands payment... Regularly back up your data...";
            }
            else if (lowerQuery.Contains("how are you"))
            {
                currentTopic = null;
                return "I'm doing well, thank you for asking!";
            }
            else if (lowerQuery.Contains("what's your purpose") || lowerQuery.Contains("what is your purpose"))
            {
                currentTopic = null;
                return "My purpose is to provide you with information and raise awareness about cybersecurity topics.";
            }
            else if (lowerQuery.Contains("what can i ask you about"))
            {
                currentTopic = null;
                return "You can ask me about topics like password safety, phishing, safe browsing, malware, scam, social engineering, and general online security tips.";
            }
            // Conversation Flow - Follow-up questions
            else if (currentTopic != null)
            {
                if (lowerQuery.Contains("more detail") || lowerQuery.Contains("explain further") || lowerQuery.Contains("tell me more"))
                {
                    switch (currentTopic)
                    {
                        case "password safety":
                            return "For example, using a combination of uppercase and lowercase letters makes it harder for attackers to guess your password. Numbers and symbols add another layer of complexity. Unique passwords prevent a breach in one account from compromising others.";
                        case "scams":
                            return "Scammers often use urgent language or threats to pressure you into acting quickly without thinking. They might also impersonate well-known companies to gain your trust.";
                        case "privacy":
                            return "Reviewing privacy settings allows you to limit who can see your posts and personal information on social media. Understanding privacy policies helps you know how your data is being used.";
                        case "phishing":
                            return "Phishing emails often contain grammatical errors or unusual formatting. The links they provide might look similar to legitimate websites but have subtle differences in the URL.";
                        case "safe browsing":
                            return "HTTPS ensures that the communication between your browser and the website is encrypted, protecting your data from being intercepted.";
                        case "malware":
                            return "Malware can include viruses, worms, and trojans, each designed to harm your system in different ways, such as deleting files or stealing data.";
                        case "social engineering":
                            return "Attackers might pretend to be customer support or a colleague to trick you into revealing sensitive information.";
                        case "data privacy":
                            return "Limiting the data you share reduces your digital footprint and the potential for misuse of your personal information.";
                        case "mobile security":
                            return "Biometric authentication like fingerprint or face recognition adds a strong layer of security to your device.";
                        case "ransomware":
                            return "Regular backups mean that even if your files are encrypted by ransomware, you can restore them without paying the ransom.";
                        default:
                            return "I can provide more details on the current topic.";
                    }
                }
                else if (lowerQuery.Contains("thank you"))
                {
                    currentTopic = null;
                    return "You're welcome! Is there anything else I can help you with?";
                }
            }
            // Memory Recall
            else if (lowerQuery.Contains("you remember") && memory.ContainsKey("name"))
            {
                currentTopic = null;
                return $"Yes, I remember you, {memory["name"]}!";
            }
            else if (memory.ContainsKey("favorite_topic") && lowerQuery.Contains(memory["favorite_topic"]))
            {
                currentTopic = memory["favorite_topic"];
                return $"Since you're interested in {memory["favorite_topic"]}, here's another tip: ..."; // Add a relevant tip
            }

            // Default response for unknown inputs
            currentTopic = null;
            return "I'm not sure I understand. Can you try rephrasing?";
        }
    }
}
