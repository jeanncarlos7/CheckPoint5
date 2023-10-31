import React, { useState } from "react";
import Menu from "../Componentes/menu";
import { DivForm, InformacoesCep, TitlePage } from "../Estilos/Estilo";
import axios from "axios";
 
function Cep() {
  const [cep, setCep] = useState("");
  const [data, setData] = useState({});
  const [error, setError] = useState(null);
 
  const [nome, setNome] = useState("");
  const [email, setEmail] = useState("");
  const [telefone, setTelefone] = useState("");
  const [endereco, setEndereco] = useState("");
 
  function handleCepChange(e) {
    setCep(e.target.value);
  }
 
  function pesquisaCEP() {
    axios
      .get(`https://viacep.com.br/ws/${cep}/json`)
      .then(function (response) {
        if (response.data && !response.data.error) {
          setData(response.data);
          setError(null);
        } else {
          setData({});
          setError("CEP NÃO ENCONTRADO");
        }
      })
      .catch(function (error) {
        setData({});
        setError("CEP NÃO ENCONTRADO");
      });
  }
 
  return (
    <>
      <Menu />
      <TitlePage> PESQUISA CEP</TitlePage>
      <div>
        <label>Nome:</label>
        <input type="text" value={nome} onChange={(e) => setNome(e.target.value)} />
      </div>
      <div>
        <label>Email:</label>
        <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
      </div>
      <div>
        <label>Número de Telefone:</label>
        <input
          type="tel"
          value={telefone}
          onChange={(e) => setTelefone(e.target.value)}
        />
      </div>
      <div>
        <label>Endereço:</label>
        <input type="text" value={endereco} onChange={(e) => setEndereco(e.target.value)} />
      </div>
      <button type="submit">Enviar</button>
      <input
        type="text"
        placeholder="Digite o CEP"
        value={cep}
        onChange={handleCepChange}
      />
      <button onClick={pesquisaCEP}>PESQUISAR</button>
      {error && <p>{error}</p>}
      {data.cep && (
        <InformacoesCep>
          <p>CEP: {data.cep} </p>
          <p>Logradouro: {data.logradouro}</p>
          <p>Complemento: {data.complemento}</p>
          <p>Bairro: {data.bairro}</p>
          <p>UF: {data.uf}</p>
          <p>DDD: {data.ddd}</p>
        </InformacoesCep>
      )}
    </>
  );
}
 
export default Cep;
 