from flask import Flask, request, jsonify

app = Flask(__name__)

@app.route('/predict', methods=['POST'])
def predict():
    data = request.get_json()
    # Example: extract features
    income = data.get('income', 0)
    age = data.get('age', 0)
    credit_score = data.get('creditScore', 0)

    # Dummy logic (replace with your ML model)
    if income > 50000 and credit_score > 700 and age > 21:
        result = "Approved"
    else:
        result = "Rejected"

    return jsonify({'result': result})

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=8000)