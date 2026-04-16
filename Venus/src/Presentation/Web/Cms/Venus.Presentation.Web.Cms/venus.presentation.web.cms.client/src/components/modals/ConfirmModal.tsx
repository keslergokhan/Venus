import type { JSX } from "react"
import { AppContext } from "../../contexts/AppContext";
import { useContext } from "react";
import { Button, Modal, ModalBody, ModalHeader } from "flowbite-react";
import { IconWarning } from "../commons";

export const ConfirmModal = () :JSX.Element =>{
    const appContext = useContext(AppContext);

    return (
        <>
            <Modal show={appContext.confirmModalState.show} size="md" onClose={() => {appContext.confirmModalAction({action:"Hidden"})}} popup>
                <ModalHeader />
                <ModalBody>
                <div className="text-center">
                    <h3 className="mb-5 text-lg font-normal text-gray-500 dark:text-gray-400">
                        <div className="flex justify-center">
                            <IconWarning color="rgb(224 89 36)" height={50} width={50}></IconWarning>
                        </div>
                        <div className="h3">{appContext.confirmModalState.title}</div>
                        {appContext.confirmModalState.body}
                    </h3>
                    <div className="flex justify-center gap-4">
                    <Button className="cursor-pointer" color="red" onClick={() => {
                        if(appContext.confirmModalState.approvalHandler){
                            appContext.confirmModalState?.approvalHandler();
                            appContext.confirmModalAction({action:"Hidden"});
                        }
                    }}>
                        Evet
                    </Button>
                    <Button className="cursor-pointer" color="alternative" onClick={() => {
                        appContext.confirmModalAction({action:"Hidden"});
                        if(appContext.confirmModalState.lastHandler){
                            appContext.confirmModalState.lastHandler();
                        }
                        }}>
                        Hayır
                    </Button>
                    </div>
                </div>
                </ModalBody>
        </Modal>
        </>
    );
}