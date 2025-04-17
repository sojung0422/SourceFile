/***************************************
  [값형식, 참조형식]
 - valueType : 복사할때 실제 값이 복사(깊은 복사)
 - 구조체는 값형식

-RefType : 복사할때 객체주소가 복사(얕은 복사)

[값에 의한 호출, 참조에의한 호출]
 - CallByValue :
 ㄴ값형식의 데이터가 전달되며 데이터가 복사되어 전달
 ㄴ메서드의 매개변수로 전달하는 경우 복사한 값이 전달되며 원본이 유지됨

 -CallBy Reference
 -참조형식의 데이터가 전달되며 주소가 복사되어 전달
 - 함수의 매개변수로 전달하는 경우 주소가 전달되며 주소를 통해 접근하기 때문에 원본을 전달하는 효과
 ***************************************/
namespace _20250404
{
    class MyClass
    {
        public int value1;
        public int value2;
    }
    struct ValueType
    {
        public int value;
    }
    class RefType
    {
        public int value;
    }

    internal class Copy
    {
        static void Swap(ValueType left, ValueType right)
        {
            int temp = left.value;
            left.value = right.value;
            right.value = temp;
        }
        static void Swap(RefType left, RefType right)
        {
            int temp = left.value;
            left.value = right.value;
            right.value = temp;
        }
        static void Main()
        {
            MyClass s = new MyClass();
            s.value1 = 1;
            s.value2 = 2;

            MyClass t = s;
            t.value1 = 3;

            ValueType valueType1 = new ValueType() { value = 10 };

            ValueType valueType2 = valueType1;  //값이 복사
            valueType2.value = 20;


            ValueType leftValue = new ValueType() { value = 10 };
            ValueType rightValue = new ValueType() { value = 20 };

            Swap(leftValue, rightValue); //데이터의 복사본이 메서드로 들어가기 때문에 원본이 바뀌지 않는다.

            Console.WriteLine($"{leftValue.value},{rightValue.value}");//10,20


            RefType leftRef = new RefType() { value = 10 };
            RefType rightRef = new RefType() { value = 20 };

            Swap(leftRef, rightRef);//원본의 주소가 메서드로 들어가기 때문에 원본이 바뀜
            Console.WriteLine($"{leftRef.value},{rightRef.value}"); //20,10
        }
    }
}
