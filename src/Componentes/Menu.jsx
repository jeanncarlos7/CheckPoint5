function menu() {
    const menu = {
        background: 'green',
        display: 'flex',
        justifyContent: 'right'
    }
    const link = {
        display: 'inlineBlock',
        textDecoration: 'none',
        padding: '30px',
        color: '#fff',
        fontSize: '20px'
    }
    return (
        <>
            <nav style={menu}>
                <ul style={{ display: 'flex', listStyle: 'none' }}>
                    <li><a href="/" style={link}>HOME</a>  </li>
                    <li><a href="/eradigital" style={link}>ERA DIGITAL</a>  </li>
                    <li><a href="/sobre"style={link} >SOBRE</a>  </li>
                    <li><a href="/cep"style={link} >CEP</a>  </li>
                </ul>
            </nav>
        </>
    )
}
export default menu;
