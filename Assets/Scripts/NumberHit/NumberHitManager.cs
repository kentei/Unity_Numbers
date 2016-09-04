using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NumberHitManger {

    /**
     * 桁数(4で固定)
     */
    public const int NumberLength = 4;
    /**
     * 答え
     */
    private string answer;
    /**
     * 推測回数
     */
    private int count;

    /**
     * 答えを返す
     * @return 答え
     */
    public string getAnswer()
    {
        return this.answer;
    }

    /**
    * コンストラクタ
    */
    NumberHitManger()
    {
        this.answer = createNumber();
    }

    /**
     * 当てる数字を生成する処理
     * @return 答え
     */
    private string createNumber()
    {
        string[] NUMBERS = { "0","1","2","3","4","5","6","7","8","9"};
        ArrayList numberList = new ArrayList(NUMBERS);
        string createdNumber = "";
        Random r = new Random();

        while (createdNumber.Length != NumberLength)
        {
            //範囲を絞っていく。(0～9、0～8、0～7…)
            int n = r.nextInt(NUMBERS.Length - createdNumber.Length);
            createdNumber += numberList.get(n);
            numberList.remove(n);
        }

        return createdNumber;
    }

    /**
     * 推測した結果(GuessResult)を返す
     * @param inputNum 入力値
     * @return 推測結果
     */
    public GuessResult getGuessResult(string inputNum)
    {
        if (!checkedInput(inputNum))
        {
            throw new InputMismatchException("OVERLAP_INPUT_NUMBER");
        }

        GuessResult result = new GuessResult();
        result = judge(inputNum, result);
        return result;
    }

    /**
     * 入力値をチェックする
     * @param inputNum 入力値
     * @return チェック結果 true: 問題なし false: 問題あり
     */
    private bool checkedInput(string inputNum)
    {
        char[] inputNumArr = inputNum.toCharArray();
        for (int i = 0; i < NumberLength; i++)
        {
            for (int j = i + 1; j < NumberLength; j++)
            {
                if (inputNumArr[i] == inputNumArr[j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    /**
     * 正解かどうかを判断する
     * @param inputNum 入力値
     * @param result 結果を詰め込む入れ物
     * @return 推測結果
     */
    private GuessResult judge(String inputNum, GuessResult result)
    {
        count++;
        if (answer.equals(inputNum))
        {
            //正解の場合
            result.setCount(count);
            result.setCorrect(true);
            result.setHitCount(4);
            result.setBlowCount(0);
            return result;
        }

        char[] answerArr = answer.toCharArray();
        char[] inputNumArr = inputNum.toCharArray();
        int hitCount = 0;
        int blowCount = 0;

        for (int i = 0; i < NumberLength; i++)
        {
            // iはinputNumArrの要素番号
            for (int j = 0; j < NumberLength; j++)
            {
                // jはanswerArrの要素番号
                if (answerArr[j] == inputNumArr[i])
                {
                    if (i == j)
                    {
                        hitCount += 1;
                    }
                    else
                    {
                        blowCount += 1;
                    }
                    break;
                }
            }
        }

        result.setCount(count);
        result.setCorrect(false);
        result.setHitCount(hitCount);
        result.setBlowCount(blowCount);

        return result;
    }
}
