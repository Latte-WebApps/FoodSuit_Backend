﻿using FoodSuit_Backend.Dishes.Domain.Model.Entities;

namespace FoodSuit_Backend.Dishes.Interfaces.REST.Resources;

public record DishResource(int Id, string Name, string Price, string Category, string Instruction, List<Products> Products);