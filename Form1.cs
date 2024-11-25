using SmsAnalysisDemo.ML;

namespace SmsAnalysisDemo
{
    public partial class Form1 : Form
    {
        private readonly ISpamDetector _spamDetector;

        public Form1(ISpamDetector spamDetector)
        {
            InitializeComponent();
            _spamDetector = spamDetector ?? throw new ArgumentNullException(nameof(spamDetector));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtMessage.Text;

            bool isSpam = _spamDetector.Check(userInput, chkZip.Checked);

            // Sonucu kullanıcıya bildiriyoruz.
            if (isSpam)
            {
                MessageBox.Show("Bu mesaj spam olarak algılandı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Mesaj spam değildir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}