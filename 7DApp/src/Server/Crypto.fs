module Crypto 

open System
open System.IO
open System.Security.Cryptography

let encrypt iv secretKey (msg: string) =
    // let payload = dict [ "payload", msg ] 
    // let jwt = Jose.JWT.Encode(payload, "top secret", JweAlgorithm.PBES2_HS256_A128KW, JweEncryption.A256CBC_HS512)
    // jwt

    use aesAlg = Aes.Create()
    aesAlg.Key  <- secretKey    |> Convert.FromBase64String
    aesAlg.IV   <- iv           |> Convert.FromBase64String

    let encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

    use msEncrypt = new MemoryStream()
    use csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
    use swEncrypt = new StreamWriter(csEncrypt)
    swEncrypt.Write(msg)
    let encrypted = msEncrypt.ToArray() |> Convert.ToBase64String
    encrypted

let decrypt iv secretKey (cipherText: string) =
    use aesAlg = Aes.Create()
    aesAlg.Key  <- secretKey    |> Convert.FromBase64String
    aesAlg.IV   <- iv           |> Convert.FromBase64String

    let decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

    use msDecrypt = new MemoryStream(cipherText |> Convert.FromBase64String)
    use csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
    use srDecrypt = new StreamReader(csDecrypt)

    srDecrypt.ReadToEnd()
