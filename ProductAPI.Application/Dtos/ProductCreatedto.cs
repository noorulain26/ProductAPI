using System;
using System.Collections.Generic;
using System.Text;
namespace ProductAPI.Application.Dtos;
public record ProductCreatedto(string Name, string Description, decimal Price, int StockQuantity);

