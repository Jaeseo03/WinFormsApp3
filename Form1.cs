using System.Diagnostics;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/Jaeseo03/WinFormsApp3";

            try
            {
                // 기본 브라우저를 통해 링크 열기
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // .NET Core 환경에서는 이 설정이 필수입니다.
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("링크를 열 수 없습니다: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            // 0~255 사이의 R, G, B 값을 무작위로 생성하여 배경색에 적용
            this.BackColor = Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "명함 사진 선택";
                ofd.Filter = "이미지 파일 (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                // 사용자가 파일을 선택하고 '확인'을 눌렀을 때만 실행
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // PictureBox의 이미지를 선택한 파일로 변경
                    // (이미지 컨트롤의 이름이 pictureBox1이라고 가정합니다)
                    pictureBox1.Image = Image.FromFile(ofd.FileName);

                    // 사진이 PictureBox 크기에 맞게 조절되도록 설정 (이미 되어있다면 생략 가능)
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
    }
}
