<?php

	$method = $_SERVER['REQUEST_METHOD'];
	
	//CABECALHO DA CONEXAO
	$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
		die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());


            
            $cpf = $_GET['cpf'];
            
            $query = "SELECT DISTINCT pedido.idpedido, pedido.FlagEntrega, pedido.total, mercado.nome, mercado.cnpj FROM pedido INNER
            JOIN pedido_item INNER JOIN mercado ON pedido.idpedido = pedido_item.Pedido_idpedido AND pedido_item.Item_mercado_cnpj = mercado.cnpj 
            WHERE pedido.Cliente_cpf = '$cpf' and pedido.FlagEntrega != 0 ";
            
            $result = mysqli_query($conexao, $query);
	        if (!$result)
	    	    "Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
	    	    
    	    $rows = array();
	        $i = 0;
	        
            while($r = mysqli_fetch_assoc($result)) {
                $rows['Rastreio'][$i]['id'] = $r['idpedido'];
                $rows['Rastreio'][$i]['total'] = $r['total'];
                $rows['Rastreio'][$i]['mercado'] = $r['nome'];
                $rows['Rastreio'][$i]['cnpj'] = $r['cnpj'];
                
                if($r['FlagEntrega'] == 1){
                    $rows['Rastreio'][$i]['status'] = 'Aguardando separação';
                }else if($r['FlagEntrega'] == 2){
                    $rows['Rastreio'][$i]['status'] = 'Em rota de entrega';
                }else{
                    $rows['Rastreio'][$i]['status'] = 'Entregue';
                }

                $i++;
            }
        
            echo json_encode($rows);
        
?>