let saniye = parseInt(prompt('Lütfen saniye değerini giriniz: '));
console.log('Girilen saniye değeri: ' + saniye);
let dakika = parseInt(saniye / 60);
saniye = saniye % 60;
console.log(dakika + ' dakika ' + saniye + ' saniye.');

//ÖNERİ:
/*
    Girilen saniye değerini 1 saat 45 dk 40 sn şeklinde gösterin
*/

