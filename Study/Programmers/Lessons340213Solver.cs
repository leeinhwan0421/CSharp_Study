using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Programmers
{
    // https://school.programmers.co.kr/learn/courses/30/lessons/340213
    // [PCCP 기출문제] 1번 / 동영상 재생기

    internal class Lessons340213Solver
    {
        /// <summary>
        /// 문제 풀이
        /// </summary>
        /// <param name="video_len">비디오 길이</param>
        /// <param name="pos">현재 위치</param>
        /// <param name="op_start">오프닝 시작 위치</param>
        /// <param name="op_end">오프닝 종료 위치</param>
        /// <param name="commands">명령어 리스트</param>
        /// <returns></returns>
        public string solution(string video_len, string pos, string op_start, string op_end, string[] commands)
        {
            string answer = SkipOpeningCommand(pos, op_start, op_end);

            foreach (string command in commands)
            {
                switch(command)
                {
                    case "next":
                        answer = NextCommand(answer, video_len);
                        break;
                    case "prev":
                        answer = PrevCommand(answer);
                        break;
                }

                answer = SkipOpeningCommand(answer, op_start, op_end);
            }

            return answer;
        }

        /// <summary>
        /// mm:ss 형태로 이루어진 문자열을 정수로 변환합니다.
        /// </summary>
        /// <param name="text">mm:ss 형태로 이루어진 문자열</param>
        /// <returns>mm * 60 + ss 값</returns>
        public int FormattedStringToInteger(string text)
        {
            string[] splited = text.Split(':');

            return (int.Parse(splited[0]) * 60) + int.Parse(splited[1]);
        }

        /// <summary>
        /// 정수를 mm:ss 형태로 이루어진 문자열로 변환합니다.
        /// </summary>
        /// <param name="value">정수</param>
        /// <returns>mm:ss 형태의 문자열</returns>
        public string IntegerToFormattedString(int value)
        {
            int min = value / 60;
            int sec = value % 60;

            return $"{min:00}:{sec:00}";
        }

        /// <summary>
        /// 10초 더하는 함수
        /// </summary>
        public string NextCommand(string pos, string video_len)
        {
            int converted_pos = FormattedStringToInteger(pos);
            int converted_video_len = FormattedStringToInteger(video_len);
            int converted_result = Math.Min(converted_pos + 10, converted_video_len);

            return IntegerToFormattedString(converted_result);
        }

        /// <summary>
        /// 10초 빼는 함수
        /// </summary>
        public string PrevCommand(string pos)
        {
            int converted_pos = FormattedStringToInteger(pos);
            int converted_result = Math.Max(converted_pos - 10, 0);

            return IntegerToFormattedString(converted_result);
        }

        /// <summary>
        /// 오프닝 스킵 함수
        /// </summary>
        public string SkipOpeningCommand(string pos, string op_start, string op_end)
        {
            int converted_op_start = FormattedStringToInteger(op_start);
            int converted_op_end = FormattedStringToInteger(op_end);
            int converted_pos = FormattedStringToInteger(pos);

            if (converted_op_start <= converted_pos && 
                converted_op_end >= converted_pos)
            {
                return op_end;
            }

            return pos;
        }
    }
}
