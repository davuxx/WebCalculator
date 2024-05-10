function getDisplay() {
    return document.querySelector("#calc-display");
}
function addText(text) {
    const display = getDisplay();
    display.innerHTML += text;
}
function clearDisplay() {
    const display = getDisplay();
    display.innerHTML = "";
}

function calculateResult() {
    const display = getDisplay();
    $.ajax({
        url: "/Home/CalculateMathProblem",
        type: "POST",
        data: { mathProblem: display.innerText },
        success: function (response) {
            display.innerHTML = response.result;
            addMathProblemToHistory(response);
        },
        error: function (request, status, error) {
            alert("Invalid input!");
        }
    });
}
function getOperationChar(operationNumber) {
    switch (operationNumber) {
        case 0:
            return '+';
        case 1:
            return '-';
        case 2:
            return '*';
        case 3:
            return '/';
        default:
            return '?';
    }
}

function addMathProblemToHistory(mathProblem, maxItems = 10) {
    const historyList = document.querySelector("#calculation-history");
    let newHistoryListItem = document.createElement("li");
    newHistoryListItem.className = "list__item";
    newHistoryListItem.innerHTML = `${mathProblem.firstNumber} ${getOperationChar(mathProblem.operation)} ${mathProblem.secondNumber} = ${mathProblem.result}`
    historyList.insertBefore(newHistoryListItem, historyList.firstChild);
    while (historyList.children.length > maxItems) {
        historyList.removeChild(historyList.lastChild);
    }
}