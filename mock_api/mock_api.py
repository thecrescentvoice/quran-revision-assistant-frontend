from flask import Flask, request, jsonify

app = Flask(__name__)

@app.route('/revise', methods=['POST'])
def revise():
    data = request.get_json() or {}
    # The frontend sends {"text": "..."}
    text = data.get('text') or data.get('inputText') or ''
    # Simple mock behavior: return the text uppercased and a short note
    revised = text.upper()
    return jsonify({"revisedText": revised, "note": "mock server: returned uppercased text"})

if __name__ == '__main__':
    # Run on port 8000 to match frontend default
    app.run(host='0.0.0.0', port=8000)
