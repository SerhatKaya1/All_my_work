// let n = prompt('Bir sayı giriniz: ');
// let asalMi;
// for (let i = 2; i <= n; i++) {
//     asalMi=true;
//     for (let j = 2; j < i; j++) {
//         if (i % j ===0 ) {
//             asalMi=false;
//         }        
//     }
//     if(asalMi===true){
//         console.log(i);
//     }
// }

let n = prompt('Bir sayı giriniz');

nextPrime:
for (let i = 2; i <= n; i++) {
    for (let j = 2; j < i; j++) {
        if (i % j === 0) {
            continue nextPrime;
        }
    }
    console.log(i);
}
