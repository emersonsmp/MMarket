<?php

    $method = $_SERVER['REQUEST_METHOD'];

    $conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
        die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());
    

    //FINALIZA PEDIDO
    if($method == 'POST'){

        $cpf  = $_POST['cpf' ];
        $cnpj = $_POST['cnpj'];
        $metodo  = $_POST['metodo' ];
        $troco = $_POST['troco'];
            
        //QUERY QUE RETORNA A ID DO PEDIDO
        $query = "SELECT DISTINCT pedido.idpedido
            FROM pedido 
            INNER JOIN pedido_item 
       
            ON pedido.idpedido = pedido_item.Pedido_idpedido
       
            WHERE pedido.FlagEntrega = 0 
            AND pedido.Cliente_cpf = $cpf 
            AND pedido_item.Item_mercado_cnpj = $cnpj";
            
        $result = mysqli_query($conexao, $query);
		if (!$result)
		    "Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";	
    
    	$resposta = $result->fetch_assoc();
    	$IdDoPedido = $resposta['idpedido'];
    	    
    	//QUERY PARA SETAR O PEDIDO COMO FINALIZADO
    	$query = "UPDATE pedido SET FlagEntrega = 1, TipoPagamento = '$metodo', Troco = '$troco' 
    	  WHERE idpedido = $IdDoPedido";
    	    
    	$result = mysqli_query($conexao, $query);
		if (!$result)
		    "Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
			    
    	echo json_encode("$IdDoPedido");
    }
    
?>