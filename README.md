# 🎓 FaculSys – Gestão Simples Universitária

Sistema acadêmico simples desenvolvido para gerenciar **alunos, professores, disciplinas, matrículas e notas** em um ambiente universitário.

## 🧾 Descrição do Projeto

O **FaculSys** é uma aplicação web desenvolvida em ASP.NET com SQL Server, com o objetivo de oferecer uma plataforma simples e funcional para:

- Cadastrar alunos, professores e disciplinas
- Realizar matrículas de alunos em disciplinas
- Permitir o lançamento de notas por professores
- Disponibilizar boletins para consulta pelos alunos
- (Opcional) Exportar boletins em PDF
- (Opcional) Relatórios acadêmicos

Este sistema é voltado para fins didáticos e acadêmicos, com foco em conceitos básicos de desenvolvimento full stack com .NET.

---

## ⚙️ Tecnologias Utilizadas

| Camada       | Tecnologia                  |
|--------------|-----------------------------|
| Backend      | C# com ASP.NET (MVC ou Web API) |
| Frontend     | HTML5, CSS3, JavaScript (ou Razor Pages) |
| Banco de Dados | SQL Server (via Management Studio) |
| IDEs         | Visual Studio, Visual Studio Code |
| PDF (extra)  | iTextSharp ou biblioteca similar (opcional) |

---

## 🧩 Funcionalidades

- [x] Cadastro de Alunos
- [x] Cadastro de Professores
- [x] Cadastro de Disciplinas
- [x] Matrícula de Alunos em Disciplinas
- [x] Lançamento de Notas pelos Professores
- [x] Consulta de Boletim pelo Aluno
- [ ] Geração de PDF do Boletim *(extra)*
- [ ] Login por perfil (Aluno / Professor) *(extra)*
- [ ] Relatórios personalizados *(extra)*

---


## 🔌 Como Rodar Localmente

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) e Management Studio
- Visual Studio 2022 ou superior

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/faculsys.git
   cd faculsys

2. Abra o projeto no Visual Studio.

3. Configure a string de conexão no arquivo appsettings.json:

  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=FaculSysDB;Trusted_Connection=True;"
  }

4. Rode as migrations (caso use EF Core):

  dotnet ef database update
  Execute o projeto (Ctrl + F5 no Visual Studio)
