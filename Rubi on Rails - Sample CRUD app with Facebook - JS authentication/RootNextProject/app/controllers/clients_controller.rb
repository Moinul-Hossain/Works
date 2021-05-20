class ClientsController < ApplicationController
http_basic_authenticate_with name: "rootnext", password: "secret"
def index
 @clients = Client.all
end

def new
end

def create
 @client = Client.new(client_params)
 @client.save
 redirect_to @client
end

def show
  @client = Client.find(params[:id])
end

def edit
 @client = Client.find(params[:id])
end

def update
  @client = Client.find(params[:id])
 
  if @client.update(client_params)
    redirect_to @client
  else
    render 'edit'
  end
end

def destroy
  @client = Client.find(params[:id])
  @client.destroy
 
  redirect_to clients_path
end

private
 def client_params
  params.require(:client).permit(:name, :contact_name, :contact_phone, :contact_email, :facebook_email, :facebook_account);
 end
end