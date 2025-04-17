namespace _20250404
{
    //캐릭터 타입을 열거형으로 정의
    enum CharacterType
    {
        Warrior, Mage, Archer
    }
    struct Character
    {
        public string name;
        public CharacterType type;
    }
    internal class Program
    {
        //캐릭터의 정보를 입력받는 메서드
        public void InputCharacter(ref Character character)//구조체는 ref
        {
            Console.Write("이름 : ");
            character.name = Console.ReadLine();

            Console.Write("직업(0 : 전사, 1: 마법사 2 : 궁수)");
            int typeInput = int.Parse(Console.ReadLine());

            //열거타입으로 형변환
            //character.type = (CharacterType)typeInput;

            //입력한 숫자가 CharacterType(열거형)안에 있냐 없냐?

            if (Enum.IsDefined(typeof(CharacterType), typeInput))
            {
                character.type = (CharacterType)typeInput;
            }
            else
            {
                Console.WriteLine("유효하지 않은 타입이다.");
            }
        }
        public void PrintCharacter(in Character character)
        {
            Console.WriteLine($"{character.name}, Type : {character.type} ");
        }
        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("캐릭터를 몇명?");
            int count = int.Parse(Console.ReadLine());

            Character[] characters = new Character[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}번 캐릭터의 정보 : ");
                program.InputCharacter(ref characters[i]);
            }

            for (int i = 0; i < characters.Length; i++)
            {
                program.PrintCharacter(characters[i]);
            }

            foreach (Character character in characters)
            {
                program.PrintCharacter(character);
            }
        }
    }
}

