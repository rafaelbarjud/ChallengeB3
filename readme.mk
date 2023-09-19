# ChallengeB3

Desafio proposto para cargo de desenvolvedor.

## Instala��o

1) Realizar o download do Node JS https://nodejs.org/en/download

2) Abrir seu prompt de comando e conferir a instala��o do node atrav�s do seguinte comando
```bash
node --version
```

3) Realizar a instala��o do angular
```bash
npm i @angular/cli
```

4) Realizar a instala��o do GIt https://git-scm.com/book/en/v2/Getting-Started-Installing-Git

5) Abrir o git bash clonar o repositorio
```bash
git clone https://github.com/rafaelbarjud/ChallengeB3.git
```

6) No terminal navegar at� a pasta do projeto web
```bash
cd .\ChallengeB3\ChallengeB3.WebApp\challengeb3-app\
```

7) Realizar a instala��o dos pacotes do angular
```bash
npm install
```

8) Buildar o web app (O build ira gerar uma pasta wwwroot com  os arquivos estaticos)
```bash
ng build
```

9) Abrir a solution clicar como bot�o direiro do mouse no projeto ChallengeB3.API e clicar na o��o "Set as startup project " e configurar como startup project.

10) Buildar a solutio CTRL+SHIFT+B

11) Rodar a solution apertando "F5"

## Testes

1) Navegar at� o projeto de testes
```bash
 cd .\ChallengeB3.API.Tests\
```

2) Executar o comando de teste
```bash
 dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
```

3) Gerar os relatorios
```bash
 reportgenerator -reports:"coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```

4) Navegar at� a pasta coverage reporte e abrir o arquivo index.html
4) Navegar at
  

