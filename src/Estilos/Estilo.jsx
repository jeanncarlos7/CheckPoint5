import styled from "styled-components";
export const lightTheme = {
    corFundo: '#0a0a0a', // Cor de fundo escura
    corTexto: '#00ff00', // Cor do texto verde brilhante
    corTitulo: '#007fff' // Cor do título azul brilhante
}

export const darkTheme = {
    corFundo: '#121212', // Cor de fundo escura
    corTexto: '#ffff', // Cor do texto verde brilhante
    corTitulo: '#0d8011' // Cor do título azul brilhante
}

// Criando uma div
export const Container = styled.div`
    background-color: ${props => props.theme.corFundo};
    color: ${props => props.theme.corTexto};
`
// Criando um botão
export const Button = styled.button`
    padding: 20px;
    border: none;
    background-color: #0d8011;
    color: white;
    margin: 15px;
`
// Criando um título
export const TitlePage = styled.h1`
    color: white;
    font-size: 25px;
`
export const InformacoesCep = styled.div`
    margin: 25px;
    display: flex;
    flex-direction: column;
`
// Criando uma div para formulários
export const DivForm = styled.div`
    display: inline;
    background-color: white;
    `