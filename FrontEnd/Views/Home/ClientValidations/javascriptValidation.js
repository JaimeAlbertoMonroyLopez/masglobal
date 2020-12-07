function AllowOnlyIntegers(inputText) {
    var pattern = new RegExp("^[0-9]*$");
    var validator = pattern.test(inputText);
}

function RiseAlert() {
    alert("Javascript working");
}