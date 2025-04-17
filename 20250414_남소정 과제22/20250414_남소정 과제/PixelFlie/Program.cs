
//png.Save("teleporter_hit.bmp", System.Drawing.Imaging.ImageFormat.Bmp); // BMP로 저장하면 압축이 안되기 때문에 용량이 커짐 -> PNG를 BMP로 변환하여 사용하는게 용량 크게 잡히지 않음
using System;
using System.Drawing;
using System.Threading;

class Program
{
    static void Main()
    {
        // 이미지 전체를 불러옴
        Bitmap sheet = new Bitmap("zitchrun.png");  // ← 이름 변경 추천 (공백 없이)

        int frameWidth = 80;
        int frameHeight = 80;
        int frameCount = sheet.Width / frameWidth;

        for (int i = 0; i < frameCount; i++)
        {
            Rectangle rect = new Rectangle(i * frameWidth, 0, frameWidth, frameHeight);
            Bitmap frame = sheet.Clone(rect, sheet.PixelFormat);

            // 콘솔 출력
            for (int y = 0; y < frame.Height; y++)
            {
                for (int x = 0; x < frame.Width; x++)
                {
                    Color pixel = frame.GetPixel(x, y);
                    if (pixel.A < 50)
                    {
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ClosestConsoleColor(pixel);
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.ResetColor();
            Thread.Sleep(80); // 프레임 간 딜레이
            Console.Clear();  // 다음 프레임 위해 지움
        }
    }

    // 픽셀 색 → ConsoleColor로 매핑
    static ConsoleColor ClosestConsoleColor(Color color)
    {
        if (color.A < 50) return ConsoleColor.Black;
        if (color.R > 200 && color.G < 100 && color.B < 100) return ConsoleColor.Red;
        if (color.B > 200 && color.R < 100 && color.G < 100) return ConsoleColor.Blue;
        if (color.R > 200 && color.G > 200 && color.B < 100) return ConsoleColor.Yellow;
        if (color.R > 200 && color.G > 200 && color.B > 200) return ConsoleColor.White;
        if (color.R < 50 && color.G < 50 && color.B < 50) return ConsoleColor.Black;
        return ConsoleColor.Gray;
    }
}
