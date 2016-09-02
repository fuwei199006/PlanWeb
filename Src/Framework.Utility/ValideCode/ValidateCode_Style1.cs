using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace Framework.Utility.ValideCode
{
    public class ValidateCode_Style1:ValidateCodeType
    {

        private Color backgroundColor = Color.White;
        private bool chaos = true;
        private Color chaosColor = Color.FromArgb(170, 170, 0x33);
        private Color drawColor = Color.FromArgb(50, 0x99, 0xcc);
        private bool fontTextRenderingHint;
        private int imageHeight = 30;
        private int padding = 1;
        private int validataCodeLength = 4;
        private int validataCodeSize = 0x10;
        private string validataCodeFont = "Arial";
        public override byte[] CreateImage(out string resultCode)
        {
            Bitmap bitmap;
            string formatString = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            GetRandom(formatString,this.validataCodeLength,out resultCode);
            var stream=new MemoryStream();
            this.ImageBmp(out bitmap, resultCode);
            bitmap.Save(stream,ImageFormat.Png);
            bitmap.Dispose();
            bitmap = null;
            stream.Close();
            stream.Dispose();
            return stream.GetBuffer();

        }

        private static void GetRandom(string formatString, int len, out string codeString )
        {
            codeString = string.Empty;
            string[] strArray = formatString.Split(',');
            var random=new Random();

            for (int i = 0; i < len; i++)
            {
                int index = random.Next(0x186a0)%strArray.Length;
                codeString = codeString + strArray[index];
            }
        }

        private void ImageBmp(out Bitmap bitmap, string validataCode)
        {
            var width = (int) (this.validataCodeLength*this.validataCodeSize);
            bitmap = new Bitmap(width, this.imageHeight);
            this.DisposeImageBmp(ref bitmap);
            this.CreateImageBmp(ref  bitmap,validataCode);
        }


        private void CreateImageBmp(ref Bitmap bitmap, string validataCode)
        {
            var graphics = Graphics.FromImage(bitmap);
            if (this.fontTextRenderingHint)
            {
                graphics.TextRenderingHint=TextRenderingHint.SingleBitPerPixel;
            }
            else
            {
                graphics.TextRenderingHint=TextRenderingHint.AntiAlias;
            }

            var font=new Font(this.validataCodeFont,this.validataCodeSize,FontStyle.Regular);
            var brush=new SolidBrush(this.drawColor);
            int maxValue = Math.Max(this.imageHeight - this.validataCodeSize - 5, 0);
            var random=new Random();
            for (int i = 0; i < this.validataCodeLength; i++)
            {
                int[] numArr=new int[] {i*this.validataCodeSize+random.Next(1)+3,random.Next(maxValue)-4};
                var point=new Point(numArr[0],numArr[1]);
                graphics.DrawString(validataCode[i].ToString(),font,brush,point);
            }
            graphics.Dispose();
        }

        private void DisposeImageBmp(ref Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            var pen=new Pen(this.drawColor,1f);
            var pointArr=new Point[2];
            var random=new Random();
            if (this.chaos)
            {
                pen=new Pen(this.chaosColor,1f);
                for (int i = 0; i < validataCodeLength*2; i++)
                {
                    pointArr[0]=new Point(random.Next(bitmap.Width),random.Next(bitmap.Height));
                    pointArr[1]=new Point(random.Next(bitmap.Width),random.Next(bitmap.Height));
                    graphics.DrawLine(pen,pointArr[0],pointArr[1]);
                }
            }
            graphics.Dispose();
        }

     

        public Color BackgroundColor
        {
            get { return this.backgroundColor; }
            set { this.backgroundColor = value; }
        }

        public bool Chaos
        {
            get { return this.chaos; }
            set { this.chaos = value; }
        }

        public Color ChaosColor
        {
            get
            {
                return this.chaosColor;
            }
            set
            {
                this.chaosColor = value;
            }
        }

        public Color DrawColor
        {
            get
            {
                return this.drawColor;
            }
            set
            {
                this.drawColor = value;
            }
        }

        private bool FontTextRenderingHint
        {
            get
            {
                return this.fontTextRenderingHint;
            }
            set
            {
                this.fontTextRenderingHint = value;
            }
        }

        public int ImageHeight
        {
            get
            {
                return this.imageHeight;
            }
            set
            {
                this.imageHeight = value;
            }
        }

        public override string Name
        {
            get
            {
                return "线条干扰(蓝色)";
            }
          
        }

        public int Padding
        {
            get
            {
                return this.padding;
            }
            set
            {
                this.padding = value;
            }
        }

        public int ValidataCodeLength
        {
            get
            {
                return this.validataCodeLength;
            }
            set
            {
                this.validataCodeLength = value;
            }
        }

        public int ValidataCodeSize
        {
            get
            {
                return this.validataCodeSize;
            }
            set
            {
                this.validataCodeSize = value;
            }
        }

        public string ValidateCodeFont
        {
            get
            {
                return this.validataCodeFont;
            }
            set
            {
                this.validataCodeFont = value;
            }
        }
    }
}