<?php

	$method = $_SERVER['REQUEST_METHOD'];
	
	//CABECALHO DA CONEXAO
	$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
		die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());


    //RETORNA LISTA DOS PEDIDOS ENCERRADOS E PARA ENTREGAR DE ACORDO COM FLAG STATUS
    if($method == 'GET'){
            
        $cnpj = $_GET['cnpj'];
        $flagEntrega = $_GET['flag'];
            
        $query = "SELECT DISTINCT pedido.idpedido, pedido.total, pedido.Cliente_cpf AS cpf, cliente.nome, 
        cliente.endereco, cliente.numero,pedido.DataVenda, pedido.FlagEntrega, pedido.DataEntrega, pedido.Troco, 
	    pedido.TipoPagamento
			
        FROM pedido JOIN pedido_item JOIN cliente
        ON pedido.idpedido = pedido_item.Pedido_idpedido AND pedido.Cliente_cpf = cliente.cpf
        WHERE pedido.FlagEntrega = $flagEntrega AND pedido_item.Item_mercado_cnpj = '$cnpj'";
			
            
        $result = mysqli_query($conexao, $query);
            
	    if (!$result)
	    	"Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
	    	    
    	$rows = array();
    	$rows['quant'] = mysqli_num_rows($result);
	
        while($r = mysqli_fetch_assoc($result)) {
            $rows['pedidos'][] = $r;
        }
        
        echo json_encode($rows);  
       
    }
    

    //SETA STATUS DO PEDIDO
    if($method == 'POST'){
        
            
            $IdPedido = $_POST['IdPedido'];
            $status   = $_POST['status'];
            
            $query = "UPDATE `pedido` SET `FlagEntrega`= '$status' WHERE `idpedido` = '$IdPedido' ";
            $result = mysqli_query($conexao, $query);
	        
	        if (!$result){ 
			    "Erro de conexão com banco de dados, o seguinte erro ocorreu -> "; 
		    }else{
			    $true = array('success' => 'true', 'message' => "Registered user");	
			    echo json_encode($true);
		    }	
        }

?>



