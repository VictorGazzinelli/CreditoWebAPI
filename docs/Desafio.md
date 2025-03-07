# DESAFIO

## PROJETO ENTREVISTAS SQUAD

**EximiaCo**

---

# CONTEXTO GERAL DO PROBLEMA

**Colocar em prática principais conceitos**  
Este exercício tem como objetivo colocar em prática, de forma conectada, práticas de engenharia focadas em C#.

### Exemplo mais próximo do mundo real  
Busque concretizar suas decisões de design no código entregue.

### Porém o foco não é a implementação de um produto funcional  
Nossa avaliação não é sobre um projeto funcionando sem bugs, nossa intenção é avaliar as decisões tomadas para resolver os problemas propostos. O que será avaliado **não** é a completude do escopo!

### Expectativa de tempo de projeto e implementação  
Imaginamos que em até 2 horas o projeto de arquitetura e design está pronto e após isso até 5 horas de implementação. Lembrando que não é sobre implementar cada detalhe das regras.

---

# CONTEXTO GERAL DO PROBLEMA

## Gerar uma proposta de crédito consignado

No Brasil existe uma lei que permite que Fintechs realizam empréstimo consignado para aposentados. Isso significa que aposentados podem realizar um empréstimo, fazendo o pagamento via dedução direta no saldo recebido do sua aposentadoria do INSS.

Você deve desenvolver uma aplicação para realizar a **inclusão de propostas** de crédito realizadas dentro de uma loja homologada para esse fim.

Neste domínio, vamos chamar o aposentando desejando um empréstimo de **proponente**. Este proponente, vai até uma loja e é atendido por **um agente**, que deve estar homologado. O aposentado, apresenta seus dados para o agente que inicia uma **digitação da proposta**. Após inserir os dados de rendimento do proponente, o agente, solicita uma **simulação da operação** (valor desejado, parcelas). Essa proposta após ser **validada por um conjunto de regras** (próximo slide), se for considerada válida deve ser incluída para processamento.

O processamento de uma proposta passa **por 5 etapas**:  
1) Validar simulação;  
2) Análise de risco da operação;  
3) Realizar averbação (bloqueio de valor no INSS);  
4) Gerar contrato;  
5) Assinatura digital;  
6) Pagamento do empréstimo;

---

# REGRAS PARA CRIAR UMA PROPOSTA

## Regras para uma proposta válida

- Cpf, dados de rendimento (número do INSS, valor da aposentadoria), endereço e dados de contato (telefone, email) obrigatórios;
- Proponente não pode ter **propostas abertas**;
- Cpf deve estar liberado em uma **lista de Cpfs fraudadores**;
- **Agente** que está incluindo a proposta deve estar **ativo**;
- Alguns **UFs**, como **RS**, tem restrições de valores;
- **Última parcela** de pagamento não pode exceder a **idade de 80 anos** do proponente;

---

# SIMULAÇÃO DE CÁLCULO

## Regras para simular valores de uma proposta

- Máximo de parcelamento 60x  
- Valor máximo da parcela não pode ultrapassar 30% do rendimento do proponente;  
- Taxa de juros de 12% ao ano;

---

# REGRAS DE PROCESSAMENTO

## Regras para processar uma proposta

- Para efeitos de simplificação, a "implementação" de todas as etapas podem ser simuladas, simulando uma chamada http para um serviço externo;

- Considere que as 2 primeiras etapas devolvem um score (0 a 10);

- Se uma destas duas etapas obter score menor que 7, a proposta deve ser reprovada;

- Você deve considerar que este processo precisa de alta confiabilidade, ou seja não podemos ter perda de dados;

- Este processo precisa ser resiliente em caso de falhas, mantendo a consistência de dados;

---

# RESTRIÇÕES TÉCNICAS

- Testes de unidade, integração, end-2-end a critério de cada desenvolvedor;
- Decisão de arquitetura, design, modelagem e tecnologias (banco, usar orm, não usar, cache, etc) ficam de responsabilidade de cada desenvolvedor;
- Seu histórico de commits/push serão analisados;
- Subir o código para um repositório do Github;
- Essa aplicação não precisa de front-end, apenas os principais endpoints/workers para realizar o trabalho;
- Não é necessário a produção de endpoints CRUDs para cadastrar entidades de apoio (Loja, agente, etc);