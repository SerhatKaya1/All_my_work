--bir günün mağaza bazlı satışlarını getirme
--mesela ocak ayının 1.gününde hangi mağaza ne kadar ürün satışı yaptığına bakalım
--diğer uygulamada ise bir mağazanın günlere göre satış ciro dağılımına baktık.

SELECT DATE2,CITY,SUM(TOTALPRICE) AS TOTALPRICE
FROM SALES

WHERE DATE2='2019-01-01'

GROUP BY DATE2,CITY
--ORDER BY DATE2,CITY
ORDER BY DATE2,SUM(TOTALPRICE) DESC --EN ÇOK SATANA GÖRE MAĞAZALARI GETİRİR.
--BİR TARİHE GÖRE CİROLARINI ÇEKEN TARİHİ GERÇEKLEŞTİRMİŞ OLDUK.