function GetBookSummary() {

    var searchBook = document.getElementById("BookSummaryInput");

    try {
        var summary = await ChatGPTClient.GenerateSummary(searchBook);
        console.log(summary);
        //Console.WriteLine($"Summary of {bookName}: {summary}");
        document.getElementById("BookSummaryArea").innerHTML = "<p " + summary + "</p>";
    }
    catch (Exception ex)
    {
        //Console.WriteLine($"Error: {ex.Message}");
    }
}