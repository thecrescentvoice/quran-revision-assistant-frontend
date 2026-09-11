# Mock Python API for Quran Revision Assistant

This small Flask app provides a /revise endpoint used for local frontend testing.

How it behaves
- POST /revise accepts JSON with a "text" (or "inputText") field.
- Responds with JSON: { "revisedText": <UPPERCASED_TEXT>, "note": "mock server: returned uppercased text" }

Run locally (recommended)
1. Create a virtual environment (optional but recommended):
   python -m venv .venv
   # Windows (cmd): .\.venv\Scripts\activate
   # PowerShell: .\.venv\Scripts\Activate.ps1
   # macOS / Linux: source .venv/bin/activate

2. Install requirements:
   pip install -r requirements.txt

3. Run the mock server:
   python mock_api.py

The server listens on http://localhost:8000

Quick test (PowerShell / cmd):
curl -X POST http://localhost:8000/revise -H "Content-Type: application/json" -d "{\"text\":\"hello\"}"

Expected response:
{"revisedText":"HELLO","note":"mock server: returned uppercased text"}
