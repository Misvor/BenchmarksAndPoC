using Newtonsoft.Json;

namespace TestThings
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var jsonString = "{\"ReceiptStatus\":\"1\",\"Uuid\":\"b9fbdc12-e43b-4f9e-bb9c-cce211fb331b\",\"Shift_number\":\"194\",\"Fiscal_receipt_number\":\"1284\",\"Receipt_date_time\":\"1685516400000\",\"Fn_number\":\"9999078902014058\",\"Ecr_registration_number\":\"0000000001059990\",\"Fiscal_document_number\":\"137799\",\"Fiscal_document_attribute\":\"552354138\",\"Amount_total\":\"15000\"}";

            var somethingParsed = JsonConvert.DeserializeObject<TestClass>(jsonString);
            Assert.AreEqual(somethingParsed.EcrRegistrationNumber, "0000000001059990");
            Assert.AreEqual(somethingParsed.FiscalDocumentNumber, "137799");
        }
    }

    public class TestClass
    {
        public string TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        [JsonProperty("Fiscal_document_number")]
        public string FiscalDocumentNumber { get; set; }

        [JsonProperty("Ecr_registration_number")]
        public string EcrRegistrationNumber { get; set; }
    }
}