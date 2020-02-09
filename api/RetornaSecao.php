<?php
    $method = $_SERVER['REQUEST_METHOD'];
    
    if($method == 'GET')
	    $id = isset($_GET['id']) ? $_GET['id'] : '';
	
	if($method == 'POST')
	    $id = isset($_POST['id']) ? $_POST['id'] : '';
	

	$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
		die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());

	
		$sessao = $_GET['sessao'];
		$cnpj   = $_GET['cnpj'];

		$query = "SELECT * FROM produto INNER JOIN prateleira ON produto.Tipo = '$sessao' AND produto.cod_barra = prateleira.cod_barra 
		WHERE cnpj = '$cnpj' ";

		$result = mysqli_query($conexao, $query);
		if (!$result)
		"Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";

		$rows = array();
		
        while($r = mysqli_fetch_assoc($result)) {
            $rows['produto'][] = $r;
        }
        
        echo json_encode($rows);
	
?>