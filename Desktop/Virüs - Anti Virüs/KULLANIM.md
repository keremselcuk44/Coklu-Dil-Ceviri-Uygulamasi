# AntiVirus Kullanım Kılavuzu

## Hızlı Başlangıç

### 1. Uygulamayı Çalıştırma

**ÖNEMLİ**: Bu uygulama yönetici yetkisi gerektirir!

1. Visual Studio'da projeyi açın
2. Projeyi sağ tıklayın → "Run as Administrator" seçeneğini kullanın
   VEYA
3. PowerShell'i yönetici olarak açın ve şu komutu çalıştırın:
   ```powershell
   cd "C:\Users\kerem\Desktop\Virüs - Anti Virüs"
   dotnet run --project AntiVirus/AntiVirus.csproj
   ```

### 2. KeyLogger Tespit Etme

#### Senaryo 1: Çalışan KeyLogger Sürecini Tespit Etme

1. KeyLogger uygulamasını çalıştırın (test amaçlı)
2. AntiVirus uygulamasını açın
3. "Süreçleri Tara" butonuna tıklayın
4. KeyLogger süreci tespit edilirse listede görünecektir
5. Tehdidi seçip "Tehdidi Karantinaya Al" butonuna tıklayın

#### Senaryo 2: KeyLogger Dosyasını Tespit Etme

1. KeyLogger.exe dosyasının bulunduğu klasörü bulun
2. AntiVirus uygulamasını açın
3. "Klasör Tara" butonuna tıklayın
4. KeyLogger.exe'nin bulunduğu klasörü seçin
5. Tarama sonuçlarını inceleyin
6. Tespit edilen tehdidi karantinaya alın

### 3. Tam Sistem Taraması

1. "Tam Tarama" butonuna tıklayın
2. Onay verin (bu işlem uzun sürebilir)
3. Tarama ilerlemesini log panelinden takip edin
4. Tespit edilen tehditleri inceleyin

## Özellikler

### Tehdit Tespit Yöntemleri

Uygulama aşağıdaki yöntemlerle tehditleri tespit eder:

1. **İmza Tabanlı Tespit**
   - KeyLogger.exe gibi bilinen dosya adları
   - Şüpheli API çağrıları (SetWindowsHookEx, WH_KEYBOARD_LL)
   - Keylogger ile ilişkili string'ler

2. **Davranış Tabanlı Tespit**
   - Şüpheli süreç davranışları
   - Anormal bellek kullanımı

3. **Heuristik Analiz**
   - Dosya içeriğinde şüpheli pattern'ler
   - PE dosyalarında zararlı kod imzaları

### Karantina Sistemi

- Tespit edilen tehditler karantinaya alınır
- Karantina klasörü: `%AppData%\AntiVirus\Quarantine\`
- Her karantinaya alınan dosya için bilgi dosyası oluşturulur
- Gerekirse süreçler otomatik olarak sonlandırılır

## Test Senaryoları

### Test 1: KeyLogger Süreci Tespiti

```bash
# 1. KeyLogger uygulamasını çalıştır
# 2. AntiVirus'ü aç
# 3. "Süreçleri Tara" butonuna tıkla
# 4. KeyLogger sürecinin tespit edildiğini doğrula
```

### Test 2: KeyLogger Dosyası Tespiti

```bash
# 1. KeyLogger.exe dosyasının konumunu bul
# 2. AntiVirus'ü aç
# 3. "Klasör Tara" butonuna tıkla
# 4. KeyLogger.exe'nin bulunduğu klasörü seç
# 5. Dosyanın tespit edildiğini doğrula
```

### Test 3: Karantina İşlemi

```bash
# 1. Bir tehdit tespit et
# 2. Tehdidi listeden seç
# 3. "Tehdidi Karantinaya Al" butonuna tıkla
# 4. Onayla
# 5. Dosyanın karantinaya alındığını doğrula
```

## Sorun Giderme

### Uygulama Açılmıyor

- **Çözüm**: Uygulamayı yönetici olarak çalıştırdığınızdan emin olun

### Tehdit Tespit Edilmiyor

- KeyLogger'ın gerçekten çalıştığından emin olun
- Tam tarama yapmayı deneyin
- Log panelini kontrol edin

### Karantina Hatası

- Yönetici yetkilerinizin olduğundan emin olun
- Dosyanın başka bir program tarafından kullanılmadığından emin olun

## Güvenlik Uyarıları

⚠️ **Bu uygulama sadece eğitim amaçlıdır!**

- Gerçek bir antivirüs yazılımı değildir
- Üretim ortamında kullanmayın
- Gerçek güvenlik için lisanslı antivirüs yazılımları kullanın

## İpuçları

1. **Gerçek Zamanlı Koruma**: Uzun süreli kullanım için gerçek zamanlı korumayı açabilirsiniz
2. **Düzenli Tarama**: Sisteminizi düzenli olarak tarayın
3. **Log Takibi**: Log panelinden tüm işlemleri takip edebilirsiniz
4. **Tehdit Detayları**: Listeden bir tehdit seçerek detaylarını görebilirsiniz

## Destek

Bu bir eğitim projesidir. Sorularınız için proje dokümantasyonunu inceleyin.

