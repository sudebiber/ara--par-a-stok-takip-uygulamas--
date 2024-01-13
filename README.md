# Araç Parça Stok Takip Uygulaması - Nesneye Yönelik Programlama İle

## Proje Tanıtımı

Merhaba! Bu projede, otomotiv sektöründeki işletmelerin ihtiyaçlarına yönelik bir Araç Parça Stok Takip Uygulaması geliştirildi. Uygulama, C# programlama dili kullanılarak nesneye yönelik programlama prensiplerine uygun bir şekilde tasarlandı. Temel amacı, araç parça stoklarını etkili bir şekilde yönetmek ve işletmelerin stok takip süreçlerini optimize etmektir.

## Proje Özellikleri ve Prensipleri

### 1. Kullanıcı Sınıfı

- *Kapsülleme:* Kullanıcı sınıfı, kapsülleme prensibine uygun olarak kullanıcı adı ve şifre bilgilerini içermektedir. Bu, veri güvenliği ve kontrol sağlar.
  
- *Kullanıcı Dostu Giriş:* Şifre girişi, GetHiddenPassword metodunu kullanarak ekranda görünmeyen bir şekilde sağlanmıştır.

### 2. Araç Parça Hiyerarşisi

- *Soyut Sınıflar ve Kalıtım:* Ana sınıf AracParca, farklı araç parça türlerini temsil eden Far, Lastik, Motor, Fren ve Sanziman sınıflarından türetilmiştir. Bu, nesneye yönelik programlamanın temel prensiplerinden olan kalıtımı vurgular.

### 3. Stok Takip ve İşlemleri

- *StokTakip Sınıfı:* Bu sınıf, araç parça listesini ve kullanıcıları yönetir. Kullanıcılar giriş yaptıktan sonra stok durumunu görüntüleyebilir, parça ekleyebilir, silebilir ve tanımlayabilirler.

- *Parça Ekleme ve Silme İşlemleri:* StokTakip sınıfı, kullanıcıların stokta bulunan parçaları eklemelerine ve silebilmelerine imkan tanır. Ayrıca, stok miktarlarına uygun olarak güvenli silme işlemleri gerçekleştirilir.

### 4. Konsol Arayüzü

- *Kullanıcı Dostu Menü:* Kullanıcı dostu bir konsol arayüzü, kullanıcıların rahatça işlemlerini gerçekleştirebilmelerini sağlar.

- *Menü Temizleme ve Çıkış:* Kullanıcılar, programdan çıkmadan önce konsolu temizleyebilirler. Ayrıca, çıkış seçeneği ile programdan çıkabilirler.

## Proje Çalıştırma

1. Projeyi Visual Studio veya benzeri bir C# IDE kullanarak açın.
2. Projenizi derleyin ve çalıştırın.
3. Konsolda görünen menü seçeneklerini takip ederek projenin işlevselliğini keşfedin.

Bu proje, nesneye yönelik programlamanın temel prensiplerini uygulayan, kullanıcı dostu bir stok takip uygulamasıdır. Gelişmiş özellikler ekleyerek veya iş süreçlerine uygun şekilde özelleştirerek işletmelerin ihtiyaçlarına daha iyi cevap verebilirsiniz.## Projeye Özgün Değer

Bu projenin özgün değeri, otomotiv sektöründeki işletmelerin karşılaştığı spesifik zorluklara çözüm sunan esnek bir stok takip çözümü sunmasıdır. Proje, şu özellikleri içermektedir:

- *Çeşitli Araç Parça Türlerini Kapsar:* Proje, far, lastik, motor, fren ve şanzıman gibi farklı araç parça türlerini kapsayan bir hiyerarşi sunar, böylece geniş bir ürün yelpazesine uyum sağlar.

- *Kullanıcı Dostu Arayüz:* Proje, konsol üzerinde kullanıcı dostu bir arayüz sunar ve kullanıcıların stok durumunu kolayca takip etmelerini, parça eklemelerini ve silmelerini sağlar.
- ## Projeye Özgün Değer

Bu projenin özgün değeri, otomotiv sektöründeki işletmelerin karşılaştığı spesifik zorluklara çözüm sunan esnek bir stok takip çözümü sunmasıdır. Proje, şu özellikleri içermektedir:

- *Çeşitli Araç Parça Türlerini Kapsar:* Proje, far, lastik, motor, fren ve şanzıman gibi farklı araç parça türlerini kapsayan bir hiyerarşi sunar, böylece geniş bir ürün yelpazesine uyum sağlar.

- *Kullanıcı Dostu Arayüz:* Proje, konsol üzerinde kullanıcı dostu bir arayüz sunar ve kullanıcıların stok durumunu kolayca takip etmelerini, parça eklemelerini ve silmelerini sağlar.
