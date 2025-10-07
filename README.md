# **Teste de Software – Projeto de Testes com xUnit**

**Alunos:** Juliana Parreiras, Pedro Marques, Gabriel Henrique, Amanda Bicalho
**Disciplina:** Teste de Software – PUC MG

---

## **1. Introdução ao xUnit**

O xUnit é um framework de **testes unitários para aplicações .NET**, desenvolvido como uma evolução do NUnit e MSTest. Criado com o objetivo de oferecer uma abordagem mais moderna, leve e extensível para testes, o xUnit adota conceitos de **atributos `[Fact]` e `[Theory]`** para identificar métodos de teste, permitindo a execução automatizada, a parametrização de casos e a integração com ferramentas de Continuous Integration (CI).

O framework segue padrões que facilitam a aplicação de **Test Driven Development (TDD)**, promovendo uma cultura de testes desde o início do desenvolvimento. Ele é compatível com múltiplas versões do .NET, incluindo .NET Core e .NET 8, e pode ser integrado ao Visual Studio, VS Code, e pipelines de CI/CD.

O xUnit se diferencia de frameworks anteriores por:

* Separar claramente a execução dos testes da lógica de asserção;
* Incentivar **testes independentes** sem dependências de estado global;
* Permitir **mocking e setup/teardown** através de construtores e interfaces como `IClassFixture`.

---

## **2. Funcionamento do xUnit**

O xUnit identifica **métodos de teste** por meio de atributos:

* `[Fact]` → define um teste unitário simples, que não recebe parâmetros;
* `[Theory]` → define um teste parametrizado, permitindo rodar o mesmo teste com múltiplos conjuntos de dados.

Os métodos podem incluir **asserções** para validar os resultados esperados (`Assert.Equal`, `Assert.Throws`, etc.). Durante a execução, o framework descobre automaticamente os testes, executa-os e gera relatórios detalhados de sucesso ou falha.

A instalação e integração são simples via CLI do .NET:

```bash
dotnet new xunit -n CalculatorTests
dotnet add CalculatorTests reference ../Calculator/Calculator.csproj
dotnet test
```

Essa abordagem garante que os testes sejam **reprodutíveis e automatizáveis**, com cobertura contínua durante o desenvolvimento.

---

## **3. Aplicação do xUnit no Projeto Calculadora**

O projeto desenvolvido consiste em uma **Calculadora ConsoleApp1** em C#, implementando quatro operações básicas:

* **Adição (`Add`)**
* **Subtração (`Subtract`)**
* **Multiplicação (`Multiply`)**
* **Divisão (`Divide`)**

Para cada operação, foram criados **testes unitários** que verificam:

* Valores positivos, negativos e zero;
* Casos com decimais ou fracionários;
* Casos de overflow (`double.MaxValue`) e underflow (`double.Epsilon`);
* Condições especiais de divisão, incluindo **divisão por zero**, que lança `DivideByZeroException`.

### **3.1 Testes Unitários**

Os testes unitários foram desenvolvidos em **CalculatorTests** e cobrem todos os métodos isoladamente. Por exemplo:

* `Multiply_TwoPositiveNumbers_ReturnsPositiveResult()`
* `Divide_DivideByZero_ThrowsException()`

Cada teste garante que **o comportamento esperado de cada operação seja respeitado**, sem depender de outros métodos.

---

### **3.2 Testes de Integração**

Foram implementados também **testes de integração** que verificam a **interação entre múltiplos métodos** da Calculadora.

Exemplo de cenário testado:

```text
Resultado esperado de (2 + 3) * 4 / 2 - 1 = 9
```

* `Add(2,3)` → 5
* `Multiply(5,4)` → 20
* `Divide(20,2)` → 10
* `Subtract(10,1)` → 9

Esses testes garantem que a **sequência de operações combinadas** funcione corretamente, validando **o comportamento do sistema como um todo**, mesmo em cenários compostos.

---

## **4. Estratégia de Derivação dos Casos de Teste**

A derivação dos casos de teste considerou:

1. **Valores válidos e comuns** – positivos, negativos e zero;
2. **Valores extremos** – `double.MaxValue`, `double.MinValue`, `double.Epsilon`;
3. **Casos de exceção** – divisão por zero;
4. **Comportamento de ponto flutuante** – NaN, Infinity, underflow e overflow;
5. **Sequências integradas** – combinando múltiplas operações para testes de integração.

Essa abordagem garante **cobertura ampla dos cenários esperados**, incluindo situações limite e de exceção.

---

## **5. Conclusão**

O uso do xUnit neste projeto proporcionou:

* **Validação confiável das operações matemáticas** da calculadora;
* Garantia de que mudanças futuras não quebrem funcionalidades existentes;
* Base sólida para documentação de comportamento esperado de cada método.

Combinando **testes unitários e integração**, conseguimos verificar tanto a **correção individual de cada operação**, quanto a **interação entre elas em sequências de cálculo**, atendendo aos objetivos da disciplina de Teste de Software.

---

**Observações finais:**

* Todo o projeto está organizado com o **ConsoleApp1** como aplicação principal e **CalculatorTests** como projeto de teste.
* Os testes podem ser executados via `dotnet test` ou integrados em ferramentas de CI/CD.
* Este trabalho reflete as práticas recomendadas de testes em C# com xUnit, combinando **qualidade, confiabilidade e documentação**.
