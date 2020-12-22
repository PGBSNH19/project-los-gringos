document.getElementById("inviteBtn").addEventListener("click", function (event) {
    var link = FormatString(location.href);
    const el = document.createElement('textarea');
    el.value = link;
    document.body.appendChild(el);
    el.select();
    document.execCommand('copy');
    document.body.removeChild(el);
});

function FormatString(string)
{
    if (string.includes("?"))
    {
        var qLocation = string.IndexOf("?");
        string = string.Slice(qLocation);
    }
    string += "?tableId=" + jsTableId
    return string;
}