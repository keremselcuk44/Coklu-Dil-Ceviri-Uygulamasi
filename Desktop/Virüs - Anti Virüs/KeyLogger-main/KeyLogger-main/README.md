# KeyLogger

**DİKKAT — ÖNEMLİ UYARI:**  
Bu depo, tuş vuruşlarını yakalayan bir örnek kod içerir. Böyle bir yazılımın izinsiz kullanımı **yasa dışıdır** ve başkalarına ciddi zarar verebilir. Bu repository yalnızca **eğitsel**, **deneysel** ve **güvenlik araştırması** amaçlı kullanılmalıdır.
---

## Youtube Video Linki: https://youtu.be/vPozYhkLqxk

## İçerik
- `Program.cs` — tuş yakalama mantığını içeren C# kodu

---

## Amaç
Bu proje, aşağıdaki eğitimsel hedeflere yöneliktir:
- Windows altındaki düşük seviyeli klavye olaylarını anlamak (API çağrıları).
- Dosya işlemleri ve uygulama akışı yönetimini öğrenmek.
- Güvenlik araştırmalarında etik kurallar ve sorumluluklar hakkında farkındalık sağlamak.

**Not:** Amacım *casusluk* değil, *öğrenme ve güvenlik*tir.

---

## Gereksinimler
- .NET (ör. .NET 6 veya üzeri) yüklü bir Windows geliştirme ortamı.
- Visual Studio veya `dotnet` CLI.
- Kodun sadece yerel ortamda çalıştırılması önerilir.

---

## Nasıl Derlenir ve Çalıştırılır (Güvenli Mod)
1. *GetAsyncKeyState* API'si ile klavye tuş vuruşları yakalanır
2. Yakalanan tuşlar konsola yazdırılır ve dosyaya kaydedilir
3. Her 100 tuş vuruşunda bir kayıtlar e-posta ile gönderilir
4. E-postalara sistem bilgileri eklenir


---

## Güvenlik & Etik Rehberi (Zorunlu)
- **İzin:** Cihaz sahibi / kullanıcı açıkça rıza vermedikçe bu yazılım hiçbir koşulda çalıştırılmamalıdır.
- **Yasalara Uyma:** Yerel yasalar ve kurum politikalarına uyun. İşveren veya okul ortamında kullanmadan önce yazılı izin alın.
- **Veri Koruma:** Toplanan veriler gizli kişisel verilerdir. Bu verilerin korunması için şifreleme ve erişim kontrolü uygulanmalıdır.
- **Credential Yönetimi:** Parola, API anahtarı gibi hassas bilgiler asla kaynak koda basılmamalıdır. Eğer bir servise bağlanmak gerekiyorsa güvenli gizli yönetimi 
- **Yayınlama:** Bu proje kesinlikle herhangi bir paket yöneticisine/Genel GitHub reposuna bir "çalışır keylogger" olarak yüklenmemelidir.

---

## Bilinen Riskler ve Dikkat Edilmesi Gerekenler
- Kodun mevcut hali ağ üzerinden veri sızdırma içermektedir; bu **güvenlik açığı** ve kötüye kullanım riski taşır. Kodun bu kısmı kaldırılmalıdır.
- `GetAsyncKeyState` gibi API'ler sistem çağrısı yapar — yanlış kullanım sistem kararlılığını etkileyebilir.
- Gerçek dünya kullanımında antivirüs yazılımları bu tip uygulamaları zararlı yazılım olarak sınıflandırır.

---

Not: Zararlı amaçlara yardımcı olamam; ancak güvenli, eğitimsel ve yasal kullanıma yönelik her türlü desteği memnuniyetle veririm.
