// <6 kyu> 1 Two 3 Four 5!
// https://www.codewars.com/kata/1-two-3-four-5

var re = { 0: "Zero", 1: "One", 2: "Two", 3: "Three", 4: "Four", 5: "Five", 6: "Six", 7: "Seven", 8: "Eight", 9: "Nine" };

function conv(num) {
    var s = String(num);
    var len = s.length;
    var ans = "";
    for (i = 0; i < len; i++) {
        n = s[i];
        if (n % 2 == len % 2) {
            var word = "";
            var capi = n % 2 == 0;
            while (word.length <= i) {
                word += capi ? re[n].toString().toLowerCase() : re[n].toString().toUpperCase();
                capi = !capi;
            }
            ans += word.substring(0, i+1);
        }
        else {
            ans += n
        }
    }
    return ans;
}
