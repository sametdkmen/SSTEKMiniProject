using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniMailProject.Core.DTOs
{
    public class CustomResponseNoDataDto
    {
        // Data

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }

        public static CustomResponseNoDataDto Success(int statusCode)
        {
            return new CustomResponseNoDataDto { StatusCode = statusCode };
        }

        public static CustomResponseNoDataDto Fail(int statusCode, List<string> errors)
        {
            // Çoklu error durumlarında liste dönebilirim

            return new CustomResponseNoDataDto { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseNoDataDto Fail(int statusCode, string error)
        {
            // Tekli hata gösterileceği zaman bunu dönücem
            return new CustomResponseNoDataDto { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }

    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }

        public static CustomResponseDto<T> Success (int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode,List<string> errors)
        {
            // Çoklu error durumlarında liste dönebilirim

            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors};
        }

        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            // Tekli hata gösterileceği zaman bunu dönücem
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
