using System;

namespace CyberSecurityBotPart2
{
    public class ResponseGenerator
    {
        private Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
{
    {"password", new List<string> {
        "Make sure to use strong, unique passwords for each account. Avoid using personal details in your passwords.",
        "A strong password typically includes a mix of uppercase and lowercase letters, numbers, and symbols.",
        "Consider using a password manager to securely store and generate complex passwords.",
        "Avoid reusing the same password across multiple sites. If one gets compromised, others will too.",
        "Enable multi-factor authentication (MFA) whenever possible to add an extra layer of security.",
        "Change your passwords regularly, especially for sensitive accounts like banking or email."
    }},
    {"scam", new List<string> {
        "Be cautious of unsolicited emails or messages asking for personal information. Scammers often impersonate trusted organizations.",
        "Never click on suspicious links or download attachments from unknown senders to avoid scams.",
        "If something seems too good to be true, it probably is a scam.",
        "Always verify the identity of someone asking for money or personal data, especially over phone or email.",
        "Scammers often create a false sense of urgency—pause and think before you act.",
        "Use spam filters and antivirus software to detect and block scam attempts."
    }},
    {"privacy", new List<string> {
        "Review the privacy settings on your online accounts to control who sees your information.",
        "Be mindful of the personal information you share online and with apps.",
        "Consider using privacy-enhancing tools like VPNs when browsing on public networks.",
        "Think twice before accepting cookies or agreeing to terms—read what data you're sharing.",
        "Disable location tracking on apps that don't need it to minimize your digital footprint.",
        "Use encrypted messaging apps like Signal or WhatsApp for secure communication."
    }},
    {"phishing tip", new List<string> {
        "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
        "Always verify the sender's email address and look for any inconsistencies or typos.",
        "Never provide sensitive information like passwords or credit card details via email.",
        "Hover over links before clicking to check if they lead to suspicious websites.",
        "Look for generic greetings like 'Dear user'—phishing emails often lack personalization.",
        "If in doubt, contact the organisation directly using an official method instead of replying."
    }},
    {"malware", new List<string> {
        "Malware is malicious software designed to harm your device or steal information—avoid downloading files from untrusted sources.",
        "Keep your operating system, antivirus software, and applications up to date to defend against malware threats.",
        "Be wary of pop-ups offering free software or prizes—they often contain malware.",
        "Regularly scan your devices for malware using reputable antivirus tools.",
        "Avoid pirated software and suspicious websites—they are common sources of malware."
    }},
    {"ransomware", new List<string> {
        "Ransomware locks your files and demands payment—never pay the ransom as it encourages attackers.",
        "Back up your data regularly to an external or cloud drive to recover files in case of a ransomware attack.",
        "Avoid opening email attachments from unknown or suspicious sources—they may contain ransomware.",
        "Install reliable antivirus and anti-ransomware tools to detect and block threats.",
        "Keep all software updated to close vulnerabilities that ransomware may exploit."
    }},
    {"social engineering", new List<string> {
        "Social engineering tricks people into giving up confidential information—stay alert and question unexpected requests.",
        "Attackers may pose as coworkers, tech support, or officials—verify their identity before sharing any information.",
        "Be cautious about what you share on social media—it can be used for targeted social engineering attacks.",
        "Never let someone pressure you into making quick decisions involving personal or financial data.",
        "Security is not just technical—it starts with awareness and skepticism of unexpected communication."
    }},
    {"safe browsing", new List<string> {
    "Always check if a website is secure by looking for 'https://' and a padlock symbol in the address bar.",
    "Avoid clicking on suspicious ads or pop-ups—they often lead to unsafe websites.",
    "Use a reputable browser with built-in security features and keep it updated.",
    "Be cautious when downloading files or extensions—only do so from trusted sources.",
    "Consider enabling safe browsing modes or privacy extensions to block malicious sites."
}},
    {"mobile security", new List<string> {
        "Install apps only from trusted sources like the Google Play Store or Apple App Store.",
        "Keep your phone’s operating system and apps up to date to patch security flaws.",
        "Use a strong PIN, password, or biometric lock to protect your device.",
        "Avoid using public Wi-Fi without a VPN, as it can expose your data to attackers.",
        "Install antivirus or mobile security apps to detect potential threats."
    }}
};


        private Dictionary<string, List<string>> usedResponses = new Dictionary<string, List<string>>();
        private Random random = new Random();

        public string GetResponse(string keyword)
        {
            if (!keywordResponses.ContainsKey(keyword)) return null;

            List<string> allResponses = keywordResponses[keyword];

            if (!usedResponses.ContainsKey(keyword))
            {
                usedResponses[keyword] = new List<string>();
            }

            List<string> availableResponses = allResponses.Except(usedResponses[keyword]).ToList();

            if (availableResponses.Count == 0)
            {
                // Reset used responses when all have been used
                usedResponses[keyword].Clear();
                availableResponses = new List<string>(allResponses);
            }

            string selected = availableResponses[random.Next(availableResponses.Count)];
            usedResponses[keyword].Add(selected);

            return selected;
        }
    }
}
