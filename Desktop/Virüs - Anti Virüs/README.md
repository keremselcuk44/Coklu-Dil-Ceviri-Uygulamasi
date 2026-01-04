# 🛡️ AntiVirus - KeyLogger Tespit Sistemi

**Eğitim Amaçlı Antivirüs Yazılımı**

Bu proje, keylogger ve benzeri zararlı yazılımları tespit etmek için geliştirilmiş eğitim amaçlı bir antivirüs uygulamasıdır.

## ⚠️ ÖNEMLİ UYARI

Bu yazılım **sadece eğitim amaçlı** geliştirilmiştir. Gerçek bir antivirüs yazılımı değildir ve üretim ortamında kullanılmamalıdır. Güvenlik araştırması ve eğitim amaçlı kullanım için tasarlanmıştır.

## 🎯 Özellikler

### 1. **Tehdit Tespit Yöntemleri**
   - **İmza Tabanlı Tespit**: Bilinen keylogger imzalarını kullanarak tehdit tespiti
   - **Davranış Tabanlı Tespit**: Şüpheli süreç davranışlarını analiz eder
   - **Heuristik Analiz**: Dosya içeriğinde şüpheli string'leri arar
   - **Süreç İzleme**: Çalışan süreçleri gerçek zamanlı izler

### 2. **Tarama Özellikleri**
   - **Süreç Taraması**: Çalışan tüm süreçleri tarar
   - **Klasör Taraması**: Belirtilen klasörü ve alt klasörlerini tarar
   - **Tam Tarama**: Sistem genelinde kapsamlı tarama

### 3. **Karantina Sistemi**
   - Tespit edilen tehditleri karantinaya alır
   - Tehdit bilgilerini kaydeder
   - Gerekirse süreçleri sonlandırır

### 4. **Kullanıcı Arayüzü**
   - Modern ve kullanıcı dostu Windows Forms arayüzü
   - Gerçek zamanlı tarama logları
   - Tehdit listesi ve detayları
   - Kolay karantina yönetimi

## 📋 Gereksinimler

- .NET 6.0 veya üzeri
- Windows İşletim Sistemi
- Yönetici Yetkileri (Uygulama yönetici olarak çalıştırılmalıdır)

## 🚀 Kurulum ve Çalıştırma

### 1. Projeyi İndirin
```bash
git clone <repository-url>
cd "Virüs - Anti Virüs"
```

### 2. Projeyi Derleyin
```bash
dotnet build AntiVirus.sln
```

### 3. Uygulamayı Çalıştırın
**ÖNEMLİ**: Uygulamayı yönetici olarak çalıştırmanız gerekmektedir.

```bash
# Yönetici PowerShell'de:
dotnet run --project AntiVirus/AntiVirus.csproj
```

Veya Visual Studio'da projeyi açıp F5 ile çalıştırabilirsiniz.

## 📖 Kullanım Kılavuzu

### Süreç Taraması
1. "Süreçleri Tara" butonuna tıklayın
2. Sistemde çalışan tüm süreçler taranır
3. Tespit edilen tehditler listelenir

### Klasör Taraması
1. "Klasör Tara" butonuna tıklayın
2. Taranacak klasörü seçin
3. Tarama sonuçları gösterilir

### Tam Tarama
1. "Tam Tarama" butonuna tıklayın
2. Onay verin (uzun sürebilir)
3. Sistem genelinde tarama yapılır

### Tehdit Karantinaya Alma
1. Tespit edilen tehditlerden birini seçin
2. "Tehdidi Karantinaya Al" butonuna tıklayın
3. Onaylayın

### Gerçek Zamanlı Koruma
1. "Gerçek Zamanlı Koruma" butonuna tıklayın
2. Koruma açık/kapalı durumunu görebilirsiniz

## 🔍 Tespit Edilen Tehdit İmzaları

Uygulama aşağıdaki keylogger imzalarını tespit eder:

- **KeyLogger.exe** ve benzeri dosya adları
- **SetWindowsHookEx**, **WH_KEYBOARD_LL** gibi şüpheli API çağrıları
- **user32.dll** içeren şüpheli import'lar
- Keylogger ile ilişkili kayıt defteri anahtarları
- Şüpheli süreç davranışları

## 🏗️ Proje Yapısı

```
AntiVirus/
├── Core/
│   ├── ThreatSignature.cs          # Tehdit imza tanımları
│   ├── SignatureDatabase.cs        # İmza veritabanı
│   ├── ThreatDetectionResult.cs    # Tespit sonuçları
│   ├── FileScanner.cs              # Dosya tarama motoru
│   ├── ProcessScanner.cs           # Süreç tarama motoru
│   ├── QuarantineManager.cs        # Karantina yönetimi
│   └── AntiVirusEngine.cs          # Ana antivirüs motoru
├── MainForm.cs                     # Ana kullanıcı arayüzü
├── Program.cs                      # Program giriş noktası
└── app.manifest                    # Uygulama manifest dosyası
```

## 🔒 Güvenlik Notları

1. **Yönetici Yetkileri**: Uygulama sistem seviyesinde işlemler yaptığı için yönetici yetkisi gerektirir.

2. **Karantina Klasörü**: Karantinaya alınan dosyalar şu konumda saklanır:
   ```
   %AppData%\AntiVirus\Quarantine\
   ```

3. **Yanlış Pozitif**: Eğitim amaçlı olduğu için bazı zararsız uygulamalar tehdit olarak algılanabilir.

## 📝 Lisans

Bu proje eğitim amaçlı geliştirilmiştir. Ticari kullanım için uygun değildir.

## ⚖️ Yasal Uyarı

Bu yazılım sadece eğitim ve güvenlik araştırması amaçlıdır. Zararlı amaçlarla kullanılması yasaktır. Kullanıcı, yazılımı kendi sorumluluğunda kullanır.

## 🤝 Katkıda Bulunma

Bu bir eğitim projesidir. Önerileriniz ve geri bildirimleriniz memnuniyetle karşılanır.

## 📧 İletişim

Eğitim amaçlı proje - Ticari destek sağlanmamaktadır.

---

**Unutmayın**: Bu yazılım gerçek bir antivirüs değildir. Gerçek güvenlik için lisanslı, profesyonel antivirüs yazılımları kullanın.

