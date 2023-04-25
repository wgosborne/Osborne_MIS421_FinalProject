var coll = document.getElementsByClassName("collapsible");

for (let i = 0; i < coll.length; i++) {
    var content = coll[i].nextElementSibling;
    content.style.maxHeight = content.scrollHeight + "px";
    coll[i].classList.add("active");
}

function getTime() {
    let today = new Date();
    hours = today.getHours();
    minutes = today.getMinutes();

    if (hours < 10) {
        hours = "0" + hours;
    }

    if (minutes < 10) {
        minutes = "0" + minutes;
    }

    let time = hours + ":" + minutes;
    return time;
}

// Gets the first message
function firstBotMessage() {
    let firstMessage = "Welcome to Synovus's Chatbot, how can I assist you?";
    document.getElementById("botStarterMessage").innerHTML =
        '<p class="botText"><span>' + firstMessage + "</span></p>";

    let time = getTime();

    $("#chat-timestamp").append(time);
    document.getElementById("userInput").scrollIntoView(false);
}

firstBotMessage();

// Retrieves the response
function getHardResponse(userText) {
    let botResponse = getBotResponse(userText);
}

//Gets the text text from the input box and processes it
function getResponse() {
    let userText = $("#textInput").val();

    let userHtml = '<p class="userText"><span>' + userText + "</span></p>";

    $("#textInput").val("");
    $("#chatbox").append(userHtml);
    document.getElementById("chat-bar-bottom").scrollIntoView(true);

    setTimeout(() => {
        getHardResponse(userText);
    }, 1000);
}

// Handles sending text via button clicks
function buttonSendText(sampleText) {
    let userHtml = '<p class="userText"><span>' + sampleText + "</span></p>";

    $("#textInput").val("");
    $("#chatbox").append(userHtml);
    document.getElementById("chat-bar-bottom").scrollIntoView(true);

    //Uncomment this if you want the bot to respond to this buttonSendText event
    // setTimeout(() => {
    //     getHardResponse(sampleText);
    // }, 1000)
}

function sendButton() {
    getResponse();
}

function heartButton() {
    buttonSendText("Heart clicked!");
}

// Press enter to send a message
$("#textInput").keypress(function (e) {
    if (e.which == 13) {
        getResponse();
    }
});

function getBotResponse(input) {
    const prompt = input.trim();
    const apiKey = "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";
    const engineId = "davinci:ft-personal-2023-04-02-03-13-22";
    const maxTokens = 100;

    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${apiKey}`,
        },
        body: JSON.stringify({
            prompt: prompt,
            max_tokens: maxTokens,
            temperature: 0.5,
            stop: "\n",
        }),
    };

    fetch(
        `https://api.openai.com/v1/engines/${engineId}/completions`,
        requestOptions
    )
        .then((response) => response.json())
        .then((data) => {
            const AIResponse = data.choices[0].text;
            console.log(AIResponse);
            let botHtml = '<p class="botText"><span>' + AIResponse + "</span></p>";
            $("#chatbox").append(botHtml);

            document.getElementById("chat-bar-bottom").scrollIntoView(true);
        })

        .catch((error) => console.error(error));
}