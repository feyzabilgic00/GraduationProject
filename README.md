# GraduationProject
Kodluyoruz bünyesinde gerçekleştirilen Apsiyon .Net Core Bootcamp mezuniyet projesidir.

###### Proje Açıklaması
Projenin amacı, Apsiyon şirketinin Site yönetim yazılımlarından bir tanesi olan Apsis uygulamasındaki temel işlemleri gerçekleştirmektir.
<p> Proje Kodluyoruz bünyesinde gerçekleştirilen Apsiyon .Net Core kursu sonunda geliştirilmesi istenen mezuniyet projesidir. Proje Asp.Net Core Mvc (.Net 5) sürümü üzerinde geliştirilmiş ve geliştirilmeye devam edilecektir. Proje içerisinde kullanıcı ve yetkilendirme işlemleri Identity kütüphanesi aracılığıyla gerçekleştirilmiştir. </p>
<p> Bu projede katmanlı mimari yapısına ve SOLID prensipleri kullanımına dikkat edilmiştir.
ORM teknolojisi olarak Entity Framework kullanılmıştır.
Veritabanı tasarımında CodeFirst yaklaşımı kullanılmıştır.
Model sınıflarımız ile tasarım modelimiz arasındaki haritalama işlemleri Automapper ile sağlanmıştır.</p>

###### Proje Yapısı
1.Admin/Site Yöneticisi
- Daire bilgilerini girebilir.
- İkamet eden kullanıcı bilgilerini girer.
- Daire başına ödenmesi gereken aidat ve fatura bilgilerini girer(Aylık olarak). Toplu veya tek tek atama yapılabilir.
- Gelen ödeme bilgilerini görür.
- Gelen mesajları görür.
- Aylık olarak borç-alacak listesini görür.
- Kişileri listeler, düzenler, siler.
- Daire/konut bilgilerini listeler, düzenler siler.<br>
2.Kullanıcı
- Kendisine atanan fatura ve aidat bilgilerini görür.
- Kredi kartı ile ödeme yapabilir.
- Yöneticiye mesaj gönderebilir.
Proje tamalandığında yukarıdaki bütün aşamaları içeriyor olacaktır.

###### Projede Kullanılan Kütüphaneler
EntityFramework Core <br>
AspNetCore Identity<br>
Automapper<br>

###### Ön Gereklilikler ve Kurulum
Projeyi kendi bilgisayarınızda çalıştırabilmeniz için öncelikle en güncel dotnet sdk' sının kurulu olması gerekmektedir.
Veritabanı için MSSQl kullanılmıştır bunun için bilgisayarınızda MsSql kurulum olmalıdır. Tüm bu işlemlerin ardından projede <strong>package manager console</strong> alanından
<strong>DataAccess</strong> katmanını seçerek migration işlemi yapmanız gereklidir. Öncelikle projenizi <strong>WebUI</strong> alanından <strong>Set As Startup</strong> demeniz gerekiyor.
Migration işlemi için <strong>add-migration Init</strong> diyerek migration eklemelisiniz. Migration işleminin veritabanına yansıması için ardından <strong>update-database</strong> demeniz gerekir. Ardından projenizi çalıştırabilirsiniz.
Proje çalıştırıldıktan sonra örn:<strong>localhost://49686/user</strong> yönlendirme olarak <strong>user</strong> yazmanız gereklidir. Ardından sizi yönlendirecek şekilde işlemler sağlanmıştır.

