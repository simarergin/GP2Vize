# GP2Vize
Sinema Seans Takip Uygulaması


Bu proje **Windows form** uygulaması kullanılarak oluşturulmuştur. 

Projede DB olarak **Sqlite** ve ORM olarak da **Nhibernate** kullanılmaktadır.

İlk olarak Form1 projenin anasayfasıdır. Bu kısımda **menuStrip** eklenerek projemize bir navbar eklemiş oluyoruz. *Salon EKle, Film Ekle, ve Çıkış* başlıklarından oluşmaktadır. 

Form1.cs yani kod kısmına gelecek olursak tüm menü itemleri click ile aktifleştirilmesi sağlandı. Her birinin altında *MdiParent* ile form içinde form açılması sağlanmaktadır. 

### Forms Kısmı; <br/>
FilmEkle.cs <br/>
SalonEkleme.cs <br/>
Bu sınıflardan oluşmaktadır.

**Model** isimli klasörün içeriğinde *Film, Salon ve Seans* isimli classlar bulunmaktadır. Db içerisinde oluşturulan veriler tanımlanmaktadır.

**Nhibernate** isimli klasör içerisinde bulunan *Nhibernate* classı bağlantı tanımını sağlamaktadır.

datagridview bulunmaktadır. Verilen bilgiler database üzerinden kaydediliyor ve ardından datagridview de oluşturduğumuz sütunlara sırasıyla yazdırılmaktadır.

Datagridview üzerinden sütun düzenlemeden dataların *property name* kısımlarına kendi db nizde hangi isimle yazılıysa o şekilde kaydedilmelidir. Bunun sebebi ise veriler kolonlara göre ayrılıp yazılırken doğru kolonlara doğru bilgilerin kaydedilmesi içindir.

Forrm1 ekranında bulunan koltuklarda dolu koltuklar **kırmızı**, boş koltuklar ise **beyaz** gözükmektedir. 





