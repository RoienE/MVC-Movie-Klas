//  met sterretje mag de comment NIET weg * https://www.w3schools.com/js/tryit.asp?filename=tryjs_timing_clock
    function startTime() {
            var today = new Date();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            m = checkTime(m);
            s = checkTime(s);
            document.getElementById('time').innerHTML =
                h + ":" + m + ":" + s;
            var t = setTimeout(startTime, 500);
        }

        function checkTime(i) {
            if (i < 10) {i = "0" + i};  // add zero in front of numbers < 10
    return i;
        }

        function telOp() {
            var getal01 = parseInt(document.getElementById("txbGetal01").value);
            var getal02 = parseInt(document.getElementById("txbGetal02").value);
            var resultaat = getal01 + getal02;

            if (isNaN(resultaat)) {
        resultaat = "Gelieve enkel getallen in te vullen.";
    }

            document.getElementById("divresultaat").innerHTML = "" + resultaat;
        }