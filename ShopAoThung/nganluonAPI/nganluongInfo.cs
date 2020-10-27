using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAoThung.nganluonAPI
{
    public class nganluongInfo
    {
        public static readonly string Merchant_id = "49494"; // mã Merchant
        public static readonly string Merchant_password = "7a7fcbeedc6478d82adcc88a5a54bd8e";  //Merchant password
        public static readonly string Receiver_email = "vanhung3339@gmail.com";// email nhan tien
        public static readonly string UrlNganLuong = "https://sandbox.nganluong.vn:8088/nl35/checkout.api.nganluong.post.php";
        // dường dẫn khi thanh tán thành công
        public static readonly string return_url = "http://localhost:53069/confirm-orderPaymentOnline";
        // dường dẫn khi thanh tán thất bại
        public static readonly string cancel_url = "http://localhost:53069/cancel-order";

    }
}