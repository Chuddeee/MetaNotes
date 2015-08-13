using System;

namespace MetaNotes.Common
{
    /// <summary>Реализация монады MayBe в виде экстеншен-метода.</summary>
    public static class MayBeMonad
    {
        /// <summary>Монада maybe.</summary>
        /// <typeparam name="TInput">Входной тип</typeparam>
        /// <typeparam name="TResult">Выходной тип</typeparam>
        /// <param name="evaluator">Делегат для получения значения</param>
        public static TResult Maybe<TInput, TResult>(this TInput input, Func<TInput, TResult> evaluator)
            where TInput : class
            where TResult : class
        {
            if (input == null)
                return null;

            return evaluator(input);
        }
    }
}
