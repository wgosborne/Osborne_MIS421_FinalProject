
function GetBookSummary() {

    //ChatGPTClient chat = new ChatGPTClient

    var searchBook = document.getElementById("BookSummaryInput");

    try {
        var summary = ChatGPTClient.GenerateSummary(searchBook);
        console.log(summary);
        //Console.WriteLine($"Summary of {bookName}: {summary}");
        document.getElementById("BookSummaryArea").innerHTML = "<p " + summary + "</p>";
    }
    catch {
        //Console.WriteLine($"Error: {ex.Message}");
    }
}