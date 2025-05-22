
#  Cybersecurity Awareness Chatbot (Part 2)

This is a C# console-based chatbot application developed for the **PROG6221** module. The chatbot aims to raise cybersecurity awareness by engaging users in a dynamic, interactive conversation about cybersecurity topics like phishing, password safety, social engineering, and more.

---

##  Features

- ✅ **User Greeting** with name capture and memory
- ✅ **Keyword Recognition** to respond to cybersecurity-related queries
- ✅ **Dynamic Responses** using a `ResponseGenerator` class
- ✅ **Sentiment Detection** to adjust responses based on user tone
- ✅ **Conversation Flow** for follow-up questions
- ✅ **Memory & Recall** (e.g., remembering user's name and interest)
- ✅ **Error Handling** for invalid or empty input
- ✅ **Formatted Console UI** using colored output for improved readability

---

##  How It Works

The chatbot is structured using the following key classes:

### `Chatbot.cs`

Handles:
- User input/output
- Conversation memory
- Sentiment detection
- Topic-specific response logic
- Chat history tracking
- Conversation flow and recall

### `ResponseGenerator.cs`

Provides:
- A dictionary of keyword-based responses
- Random response selection for varied interactions

### `SentimentDetector.cs`

Detects:
- Positive or negative user sentiment
- Adjusts chatbot tone accordingly (e.g., support or encouragement)

### `User.cs`

Stores:
- User's name
- Can be expanded for more profile-related data

---

##  Technologies Used

- **C# .NET (Console Application)**
- **System Libraries** (`System`, `System.Collections.Generic`, `System.Linq`)
- No external dependencies

---

##  Getting Started

### Prerequisites
- Visual Studio / JetBrains Rider / VS Code with C# Extension
- .NET SDK installed (version 6.0 or above recommended)

### Running the Project

1. Clone the repository or download the source code
2. Open the project in your C# IDE
3. Build the solution
4. Run the application

---

## Example Interaction

```
Hi there! What’s your name? John

Welcome, John! 👋

Ask me anything about cybersecurity (type 'exit' to quit):

You: How do I make a strong password?
🤖: A strong password typically includes a mix of uppercase and lowercase letters, numbers, and symbols.

You: tell me more
🤖: Using a combination of characters makes it harder for attackers to guess your password...

You: thank you
🤖: You're welcome! Is there anything else I can help you with?

You: exit
🤖: Stay safe online! Thank you for your time! 👋
```

---

##  Code Quality

- Modular and OOP-structured
- Easy to expand with new topics or features
- Clean console UI with color-coded prompts

---

##  Educational Purpose

This project is part of an academic assignment for the **PROG6221** module and is intended to demonstrate:
- Practical C# skills
- AI interaction patterns
- Secure software design principles

---

##  Folder Structure

```
CyberSecurityBotPart2/
├── Chatbot.cs
├── ResponseGenerator.cs
├── SentimentDetector.cs
├── User.cs
└── Program.cs
```

---

##  Cybersecurity Topics Covered

- Password safety
- Phishing & phishing tips
- Malware & ransomware
- Scam awareness
- Social engineering
- Mobile security
- Data privacy
- Safe browsing

---

## Author

- **Student Name:** [Your Name Here]
- **Institution:** IIE MSA
- **Module:** PROG6221
- **Year:** 2025

---

##  License

This project is for **educational use only** and is not intended for production deployment.
