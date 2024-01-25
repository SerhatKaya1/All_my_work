WITH UrunAggregates AS (
    SELECT
        Urun,
        MIN(Fiyat) AS 'MinimumFiyat',
        MAX(Fiyat) AS 'MaksimumFiyat',
        AVG(Fiyat) AS 'OrtalamaFiyat'
    FROM
        Urunler
    GROUP BY
        Urun
)

SELECT
    t.Urun,
    MIN(CASE WHEN t.Fiyat = u.MinimumFiyat THEN t.Site END) AS 'Minimum Fiyatlı Site Adı',
    u.MinimumFiyat AS 'Minimum Fiyat',
    MIN(CASE WHEN t.Fiyat = u.MaksimumFiyat THEN t.Site END) AS 'Maksimum Fiyatlı Site Adı',
    u.MaksimumFiyat AS 'Maksimum Fiyat',
    u.OrtalamaFiyat AS 'Ortalama Fiyat'
FROM
    Urunler t
JOIN
    UrunAggregates u ON t.Urun = u.Urun
GROUP BY
    t.Urun, u.MinimumFiyat, u.MaksimumFiyat, u.OrtalamaFiyat;
