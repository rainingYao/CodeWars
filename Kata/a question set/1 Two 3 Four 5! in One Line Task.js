// <4 kyu> One Line Task: 1 Two 3 Four 5!
// https://www.codewars.com/kata/one-line-task-1-two-3-four-5

conv=n=>(n+="").replace(/./g,(c,i)=>(n.length^c)&1?c:(w=>(w+w[`to${c&1?"Low":"Upp"}erCase`]()).repeat(5))("zero:ONE:two:THREE:four:FIVE:six:SEVEN:eight:NINE".split`:`[c]).slice(0,i+1))
conv=n=>(n+="").replace(/./g,(c,i)=>(n.length^c)&1?c:(w=>(w+(c&1?w.toLowerCase():w.toUpperCase()).repeat(5)))("zero:ONE:two:THREE:four:FIVE:six:SEVEN:eight:NINE".split`:`[c]).slice(0,i+1))
conv=n=>(n+='').replace(/./g,(d,i)=>(n.length^d)&1?d:((w='zeroZERO|ONEone|twoTWO|THREEthree|fourFOUR|FIVEfive|sixSIX|SEVENseven|eightEIGHT|NINEnine'.split`|`[d])+w+w).slice(0,i+1))
conv=(n,A='zero one two three four five six seven eight nine ten'.split` `,S=[...n+``],l=S.length%2)=>S.map((d,i)=>[(c=A[d],A.map(_=>(b=c.toUpperCase(),l?b+c:c+b)).join``).slice(0,i+1),d][d%2^l]).join``
conv=(num,l=(n=[...num+'']).length,v='zero|one|two|three|four|five|six|seven|eight|nine'.split('|'),f=(n,o)=>n.map((a,p)=>(+a&1)==o?a:[...Array(5)].map((_,i)=>(i&1)==o?v[a].toUpperCase():v[a]).join``.slice(0,p+1)).join``)=>f(n,(l&1)^1)
// These codes are copied from the basic questions.
// How to make the codes length less than 180 ?