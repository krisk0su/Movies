﻿namespace MoviesApp.Services.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void CreateMappings(IProfileExpression configuration);
    }
}

